import os


def main():
    p = os.path.join(
        os.path.dirname(os.path.dirname(os.getcwd())),
        "src_sql/init.sql"
    )

    with open(p) as f:
        lines = f.read()

        queries = lines.split("\n\n")

        const_names = []

        q_l = []
        is_first = True
        is_left_bracket = False
        for i in queries:
            lines = i.split("\n")

            for j in lines:
                if is_left_bracket:
                    is_left_bracket = False

                elif j.startswith("CREATE TABLE"):
                    if not is_first:
                        q_l.append(f"`;")

                    else:
                        is_first = False

                    var_name = j.lower().replace(" ", "_")
                    const_names.append(var_name)
                    q_l.append(f"\nconst {var_name} = `")

                    tmp = j.split()

                    q_l.append(f"\t{tmp[0]} {tmp[1]} IF NOT EXISTS {tmp[2]} (")
                    is_left_bracket = True

                else:
                    q_l.append(f"\t{j}")
        q_l.append(f"`;")

        with open("out.js", "w") as f_2:
            for i in q_l:
                f_2.write(i + "\n")

            f_2.write("module.exports = {")

            for i in const_names:
                f_2.write(f"\t{i},\n")

            f_2.write("}")


if __name__ == '__main__':
    main()
