#!/bin/bash

#main() {
#    #echo "arguments supplied"
#    echo First arg: $1
#    args=$(echo $1 | tr " ")
#    echo args
#
#
##    sentence="this is a story"
##    a=($sentence)
##    echo a
#
#
#
#    script_full_path="${BASH_SOURCE}"
#    #echo "script full path: $script_full_path"
#    script_name=`basename "$0"`
#    #echo "script name: $script_name"
#    script_name_len=${#script_name}
#    #echo "script name len: $script_name_len"
#    full_path_name_len=${#script_full_path}
#    #echo "full path name len: $full_path_name_len"
#
#    #current_path=${script_full_path: :-$script_name_len}
#
#    l=`expr $full_path_name_len - $script_name_len`
#    tmp=$(expr substr "${script_full_path}" 1 $l)
#    current_path=$tmp
#
#    #echo "current path: $current_path"
#    dir="$current_path"
#    #echo "dir: $dir"
#    export PYTHONUNBUFFERED=1
#    #here was dir before instead of curr_path
#    python_path="$(dirname "$current_path")"
#    #echo "pyhton path: $python_path"
#
#    $python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p '{"key 1": "val 1","key 2": "val 2"}'
#    #$python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p 'string tmp val'
#
#}

encrypt() {
    #echo "arguments supplied"
    echo First arg: $1
#    args=$(echo $1 | tr " ")
#    echo args
    echo second arg: $2

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
    tmp=$(expr substr "${script_full_path}" 1 $l)
    current_path=$tmp

    #echo "current path: $current_path"
    dir="$current_path"
    #echo "dir: $dir"
    export PYTHONUNBUFFERED=1
    #here was dir before instead of curr_path
    python_path="$(dirname "$current_path")"
    #echo "pyhton path: $python_path"

    $python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p '{"key 1": "val 1","key 2": "val 2"}'
    #$python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p 'string tmp val'

}

decrypt() {
    #echo "arguments supplied"
    echo First arg: $1
#    args=$(echo $1 | tr " ")
#    echo args
    echo second arg: $2


#    sentence="this is a story"
#    a=($sentence)
#    echo a



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
    tmp=$(expr substr "${script_full_path}" 1 $l)
    current_path=$tmp

    #echo "current path: $current_path"
    dir="$current_path"
    #echo "dir: $dir"
    export PYTHONUNBUFFERED=1
    #here was dir before instead of curr_path
    python_path="$(dirname "$current_path")"
    #echo "pyhton path: $python_path"

    $python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p '{"key 1": "val 1","key 2": "val 2"}'
    #$python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p 'string tmp val'

}

global_runner() {
#    echo First arg: $1
#    echo second arg: $2


    script_full_path="${BASH_SOURCE}"
    #echo "script full path: $script_full_path"
    script_name=`basename "$0"`
    #echo "script name: $script_name"
    script_name_len=${#script_name}
    echo "script name len: $script_name_len"
    full_path_name_len=${#script_full_path}
    echo "full path name len: $full_path_name_len"

    #current_path=${script_full_path: :-$script_name_len}

    l=`expr $full_path_name_len - $script_name_len`
    echo l calculated $l
    tmp=$(expr substr "${script_full_path}" 1 $l)
    current_path=$tmp
    echo tmp $tmp

    echo "current path: $current_path"
    dir="$current_path"
    #echo "dir: $dir"
    export PYTHONUNBUFFERED=1
    #here was dir before instead of curr_path
    python_path="$(dirname "$current_path")"
#    echo "pyhton path: $python_path"


    echo 1 $1
    echo 2 $2
    echo 3 $3

    echo 4 $4
    echo 5 $5


    $python_path/venv/bin/python "$current_path/main.py" $1 $2 $3 $4 $5

#    $python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p '{"key 1": "val 1","key 2": "val 2"}'
    #$python_path/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p 'string tmp val'

}


# param 1 -e or -d
# param 2 secret_value
# param 3 p_value or c_value

#echo $1
#echo $2
#echo $3

#echo 1 $1
#echo 2 $2
#echo 3 $3
#
#echo 4 $4
#echo 5 $5

# Absolute path to this script, e.g. /home/user/bin/foo.sh
SCRIPT=$(readlink -f "$0")
# Absolute path this script is in, thus /home/user/bin
SCRIPTPATH=$(dirname "$SCRIPT")
#echo $SCRIPTPATH

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
dir="$current_path"
#echo "dir: $dir"
export PYTHONUNBUFFERED=1
#here was dir before instead of curr_path
python_path="$(dirname "$current_path")"
#    echo "pyhton path: $python_path"


if [ $# -eq 0 ]
  then
    echo {\"err\": \"No arguments supplied\"}
  else
    s_param="none"

    if [ $1 = "-e" ]
      then
#        global_runner -e -s $2 -p $3
         $python_path/venv/bin/python "$SCRIPTPATH/main.py" -e -s $2 -p $3
#        encrypt -e -s $2 -p $3
#        echo encrypt
    elif [ $1 = "-d" ]
      then
#        global_runner -d -s $2 -c $3
        $python_path/venv/bin/python "$SCRIPTPATH/main.py" -d -s $2 -c $3
#        echo decrypt
    else
      echo err


    fi

#    main $1 $2

fi

#    parser.add_argument('--encrypt', '-e', default=False,
 #                        help='encrypt flag', action='store_true')
 #
 #    parser.add_argument('--decrypt', '-d', default=False,
 #                        help='decrypt flag', action="store_true")
 #
 #    parser.add_argument('--secret', '-s', default=None,help='secret configuration, minimal: {"master_password": str}', type=json.loads)
 #
 #    parser.add_argument('--plaintext', '-p', default=None, help='plaintext',
 #                        type=str)
 #
 #    parser.add_argument('--ciphertext', '-c', default=None, help='ciphertext, minimal {"nonce": str, "ciphertext": str, "tag": str, "salt": str}',type=json.loads)


#  /bin/sh /home/tmp/Documents/github/marin-jovanovic/pet-care-app/src_py/encrypt.sh -e '{"master_password":"vD15<>$%dmqw"}' "tmp"
# /bin/sh /home/tmp/Documents/github/marin-jovanovic/pet-care-app/src_py/encrypt.sh -d '{"master_password":"vD15<>$%dmqw"}' '{"nonce":"9EUW2ZaPvJK4olxudvQdWw==","ciphertext":"wDDd","tag":"/enBi6rZ+k8alWpKTrpPsQ==","salt":"Ar9YAhFEknSTksLhibN6vw=="}'
