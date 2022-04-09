#!/bin/bash

script_full_path="${BASH_SOURCE}"
script_name=`basename "$0"`
script_name_len=${#script_name}
current_path=${script_full_path: :-$script_name_len}
dir="$current_path"

export PYTHONPATH="$(dirname "$dir")"

$PYTHONPATH/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p '{"key 1": "val 1","key 2": "val 2"}'
$PYTHONPATH/venv/bin/python "$current_path/main.py" -e -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -p 'string tmp val'

