#!/bin/bash

#python3 main.py -d -cf '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -c '{"nonce": "rOQ2d2EXzMq33PGi0h2gWg==", "ciphertext": "StbXRit4PVWAd/Se/64oneKkNfEUZwr0wVcTY668yEusE28z", "tag": "RjDCzZAyoyESZg24h0bDsw==", "salt": "gXQwvIs/5IX+0NaKJqbpsA=="}'

#!/bin/bash

script_full_path="${BASH_SOURCE}"
script_name=`basename "$0"`
script_name_len=${#script_name}
current_path=${script_full_path: :-$script_name_len}
dir="$current_path"
export PYTHONUNBUFFERED=1
export PYTHONPATH="$(dirname "$dir")"

$PYTHONPATH/venv/bin/python "$current_path/main.py" -d -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -c '{"nonce": "rOQ2d2EXzMq33PGi0h2gWg==", "ciphertext": "StbXRit4PVWAd/Se/64oneKkNfEUZwr0wVcTY668yEusE28z", "tag": "RjDCzZAyoyESZg24h0bDsw==", "salt": "gXQwvIs/5IX+0NaKJqbpsA=="}'
$PYTHONPATH/venv/bin/python "$current_path/main.py" -d -s '{"master_password": "vdadddddddddj!?<~~<>$%moawer@@f,.<~>\"12868"}' -c '{"nonce": "NjyoKRq7PtJLy8smiBBx2w==", "ciphertext": "g6zDEeTfYNKBzxe/6Xk=", "tag": "t2e/hVGJ2ZBk4M/qDWyzyA==", "salt": "xyPoTh+PkVUBdO4aeuibvg=="}'

