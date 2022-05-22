# force to run with sh
#!/bin/sh

#!/bin/bash

# param 1 -e or -d
# param 2 secret_value
# param 3 p_value or c_value

# Absolute path to this script
SCRIPT=$(readlink -f "$0")
# Absolute path to this script parent directory
SCRIPTPATH=$(dirname "$SCRIPT")
script_path_parent_dir=$(dirname "$SCRIPTPATH")
#echo $SCRIPTPATH
#echo $script_path_parent_dir
target_script_file_path="$script_path_parent_dir/src_py/aes_gcm"
#echo $target_script_file_path

script_full_path="${BASH_SOURCE}"
#echo "script full path: $script_full_path"
script_name=`basename "$0"`
#echo "script name: $script_name"
script_name_len=${#script_name}
#echo "script name len: $script_name_len"
full_path_name_len=${#script_full_path}
#echo "full path name len: $full_path_name_len"

#current_path=${script_full_path: :-$script_name_len}

l=`expr $full_path_name_len - $script_name_len`
#echo l calculated $l
tmp=$(expr substr "${script_full_path}" 1 $l)
current_path=$tmp
#echo tmp $tmp

#echo "current path: $current_path"
#dir="$current_path"
#echo "dir: $dir"
export PYTHONUNBUFFERED=1
python_path="$(dirname "$current_path")"
#    echo "pyhton path: $python_path"


if [ $# -eq 0 ]
  then
    echo {\"err\": \"No arguments supplied\"}
  else
    s_param="none"

    if [ $1 = "-e" ]
      then
         $python_path/venv/bin/python "$target_script_file_path/main.py" -e -s $2 -p $3
    elif [ $1 = "-d" ]
      then
        $python_path/venv/bin/python "$target_script_file_path/main.py" -d -s $2 -c $3
    else
      echo err

    fi
fi

#  /bin/sh /home/tmp/Documents/github/marin-jovanovic/pet-care-app/src_py/encrypt.sh -e '{"master_password":"vD15<>$%dmqw"}' "tmp"
# /bin/sh /home/tmp/Documents/github/marin-jovanovic/pet-care-app/src_py/encrypt.sh -d '{"master_password":"vD15<>$%dmqw"}' '{"nonce":"9EUW2ZaPvJK4olxudvQdWw==","ciphertext":"wDDd","tag":"/enBi6rZ+k8alWpKTrpPsQ==","salt":"Ar9YAhFEknSTksLhibN6vw=="}'
