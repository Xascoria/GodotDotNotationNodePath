import os
import re
import json
import unicodedata

# Class Name for the node path files, use something that wouldn't be use elsewhere in your project
CLASS_NAME_FOR_PATH_FILE = "NodePaths"

# If false, it would put the new class files into a new, separated folder instead
PUT_PATH_CLASSES_IN_ORIGINAL_DIR = False
# Since it's in the same folder
# if a scene with the same name already exist else where it should throw an err
THROW_ERR_IF_SAME_SCENE_NAME = True
PATH_CLASSES_FOLDER_PATH = "NodePaths"

# All of the paths are based on the root node, therefore the root node has no path
# If toggle, throw an error instead of returning empty string on root node
THROW_ERR_IF_GET_PATH_ON_ROOT = True

# Helper function to check if the name is a valid identifier in C#
def is_valid_in_identifier(c, first_char=False):
    category = unicodedata.category(c)

    allowed_categories = {
        'Lu',  # UppercaseLetter
        'Ll',  # LowercaseLetter
        'Lt',  # TitlecaseLetter
        'Lm',  # ModifierLetter
        'Lo',  # OtherLetter
    }

    allowed_categories_after_first_char = {
        'Nl',  # LetterNumber
        'Mn',  # NonSpacingMark
        'Mc',  # SpacingCombiningMark
        'Nd',  # DecimalDigitNumber
        'Pc',  # ConnectorPunctuation
        'Cf',  # Format
    }

    if category in allowed_categories or c == "_":
        return True
    elif category in allowed_categories_after_first_char and not first_char:
        return True
    else:
        return False
    
def check_class_name(class_name):
    if not is_valid_in_identifier(class_name[0], True):
        raise Exception(class_name + " has an invalid identifier in its first char!")
    
    for i in range(1, len(class_name)):
        if not is_valid_in_identifier(class_name[i]):
            raise Exception(class_name + " has an invalid identifier!")


def parse_scripts_into_dict(resource_block):
    output = {}

    for index, i in enumerate(resource_block.split('\n')):
        script_match = re.search(r'path="(.*?)"\s+type="Script"\s+id=(\d+)', i)
        if script_match:
            id_match = re.search(r'id=(\d+)', i)
            id_number = int(id_match.group(1))
            class_name = script_match.group(1).split('/')[-1]
            
            if class_name.endswith(".cs"):
                output[id_number] = class_name[:-3]
            #print(f"Extracted ID number: {id_number}",class_name)

    return output

def parse_node_into_class(node_string, nodes_dict, script_dict={}):
    node_values = node_string.strip().split('\n')

    path_pattern = r'parent="([^"]+)"'
    name_pattern = r'name="([^"]+)"'
    type_pattern = r'type="([^"]+)"'
    name = re.search(name_pattern, node_values[0]).group(1)
    check_class_name(name)
    node_type = re.search(type_pattern, node_values[0]).group(1)

    resource_pattern = r'ExtResource\(\s*(\d+)\s*\)'
    script_class = None
    for i in range(1, len(node_values)):
        if node_values[i].startswith('script = '):
            resource_id = int(re.search(resource_pattern, node_values[i]).group(1))
            if resource_id in script_dict:
                script_class = script_dict[resource_id]
                break
            

    path_match = re.search(path_pattern, node_values[0])
    true_script_class = script_class if script_class else node_type
    new_node = {
        'name': name,
        'type': true_script_class,
        'children': {},
    }

    if path_match:
        node_path = path_match.group(1)
        if node_path == '.':
            #First layer children
            nodes_dict['root']['children'][name] = new_node
        else:
            splitted_node_path = node_path.split("/")
            cur_node = nodes_dict['root']
            for node in splitted_node_path:
                cur_node = cur_node['children'][node]

            cur_node['children'][name] = new_node
    else:
        #Parent node
        nodes_dict['root'] = new_node

def recursive_write_node_to_file(file_ptr, parent_class_name, node_dict, path_so_far= []):
    tab = " " * 4

    cur_class_name = parent_class_name + '_' + node_dict['name']

    file_ptr.write('public class ' + cur_class_name + ' : IAutomatedNodePath\n{\n')
    for child in node_dict['children']:
        child_class_name = cur_class_name + '_' + child
        file_ptr.write(tab + 'public ' + child_class_name + ' ' + child + ' = new ' + child_class_name + '();\n')

    file_ptr.write(tab + 'public string GetPath() {return "'+ 
                   (node_dict['name'] if len(path_so_far) == 0 else '/'.join(path_so_far) + '/' + node_dict['name'])  + '";}\n')
    file_ptr.write(tab + 'public Node GetNode(Node rootNode) { return rootNode.GetNode<'+ node_dict['type'] +'>(GetPath()); }\n')
    file_ptr.write('}\n\n')

    for child in node_dict['children']:
        recursive_write_node_to_file(file_ptr, cur_class_name, node_dict['children'][child], [node_dict['name']])

def write_node_to_file(file_ptr, new_class_name, nodes_dict):
    tab = " " * 4

    # Write top imports
    file_ptr.write('using Godot;\nusing System;\n\n')

    # Write main NodePaths class
    root_node = nodes_dict['root']
    root_node_name = root_node['name']
    root_node_class_name = new_class_name + '_' + root_node_name
    file_ptr.write('public class '+new_class_name+'\n{\n' + tab + "public " 
                   + root_node_class_name + " " + root_node_name + " = new " + root_node_class_name + "();\n}\n\n" )

    # Write root node
    file_ptr.write('public class ' + root_node_class_name + ' : IAutomatedNodePath\n{\n')
    for child in root_node['children']:
        child_class_name = root_node_class_name + '_' + child
        file_ptr.write(tab + 'public ' + child_class_name + ' ' + child + ' = new ' + child_class_name + '();\n')
    
    if THROW_ERR_IF_GET_PATH_ON_ROOT:
        file_ptr.write(tab + 'public string GetPath() { throw new Exception("GetPath() called on Root disallowed"); }\n')
    else:
        file_ptr.write(tab + 'public string GetPath() {return "";}\n')
    file_ptr.write(tab + 'public Node GetNode(Node rootNode) { return rootNode; }\n')

    file_ptr.write('}\n\n')

    for child in root_node['children']:
        recursive_write_node_to_file(file_ptr, root_node_class_name, root_node['children'][child], [])

if not PUT_PATH_CLASSES_IN_ORIGINAL_DIR:
    if not os.path.exists(PATH_CLASSES_FOLDER_PATH):
        os.makedirs(PATH_CLASSES_FOLDER_PATH)
    else:
        # Deletes existing path file
        for filename in os.listdir(PATH_CLASSES_FOLDER_PATH):
            file_path = os.path.join(PATH_CLASSES_FOLDER_PATH, filename)
            
            if os.path.isfile(file_path):
                os.remove(file_path)

for subdir, dirs, files in os.walk(os.getcwd()):
    for filename in files:
        if filename.endswith(".tscn"):
            file_path = os.path.join(subdir, filename)

            file = open(file_path, 'r')
    
            # Read the entire file content into a string
            file_content = file.read().split("\n\n")
            file.close()
            script_dict = {}
            nodes_dict = {}

            for block in file_content:
                if block.startswith('[ext_resource'):
                    script_dict = parse_scripts_into_dict(block)
                elif block.startswith('[node'):
                    parse_node_into_class(block, nodes_dict=nodes_dict, script_dict=script_dict)
            #print(subdir)

            new_class_name = '_'+filename[:-5]+CLASS_NAME_FOR_PATH_FILE
            check_class_name(new_class_name)
            new_file_path = (subdir + "/" + new_class_name + ".cs") \
                if PUT_PATH_CLASSES_IN_ORIGINAL_DIR else (PATH_CLASSES_FOLDER_PATH + "/" + new_class_name + ".cs")
            # Throws an error if another scene have the same name 
            if not PUT_PATH_CLASSES_IN_ORIGINAL_DIR and THROW_ERR_IF_SAME_SCENE_NAME and os.path.exists(new_file_path):
                raise Exception("Another scene shares the same name, do not use common dir for the nodepath files as it would override one of them!")

            new_script_file = open(new_file_path, 'w+')

            write_node_to_file(new_script_file, new_class_name, nodes_dict)

            new_script_file.close()

