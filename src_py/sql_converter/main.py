import json
import os

def init():
    p = os.path.join(
        os.path.dirname(os.path.dirname(os.getcwd())),
        "src_sql/init.sql"
    )

    p = os.path.join(
        os.path.dirname(os.path.dirname(os.getcwd())),
        "docs/hw_2/zadaca2/KreiranjeBaze.sql"
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

        with open("init.js", "w") as f_2:
            for i in q_l:
                f_2.write(i + "\n")

            f_2.write("module.exports = {")

            for i in const_names:
                f_2.write(f"\t{i},\n")

            f_2.write("}")

def fill():

    p = os.path.join(
        os.path.dirname(os.path.dirname(os.getcwd())),
        "docs/hw_2/zadaca2/PunjenjeBP.sql"
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
                # if is_left_bracket:
                #     is_left_bracket = False

                if j.startswith("INSERT INTO "):
                    if not is_first:
                        q_l.append(f"`;")

                    else:
                        is_first = False

                    if j.__contains__("("):
                        new_j = j.split("(")[0].strip()
                        var_name = new_j.lower().replace(".", "_").replace(" ", "_")
                    else:
                        var_name = j.lower().replace(".", "_").replace(" ",
                                                                           "_")
                    print(var_name)
                    const_names.append(var_name)
                    q_l.append(f"\nconst {var_name} = `")

                    q_l.append(f"\t{j}")
                    is_left_bracket = True

                else:
                    q_l.append(f"\t{j}")
        q_l.append(f"`;")

        with open("fill.js", "w") as f_2:
            for i in q_l:
                f_2.write(i + "\n")

            f_2.write("module.exports = {")

            for i in const_names:
                f_2.write(f"\t{i},\n")

                print(f"    query = await db_index.query(seed_insert.{i}, [])")

            f_2.write("}")

def generate_cript():
    #         query = await db_index.crypto_query_wrapper(
    #         'INSERT INTO recive (userName, idmessages) VALUES ( $1, $2);',
    #         [["username",  "PeroPeric"], ["idmessages", 0]],
    #         {
    #             "__username": "PeroPeric",
    #             "__table": "recive",
    #             "__key": "ovoSeNekakoPamti!"
    #         }
    #     )

    #     query = await db_index.crypto_query_wrapper(
    #         'INSERT INTO recive (userName, idmessages) VALUES ( $1, $2);',
    #         [["username",  "PeroPeric"], ["idmessages", 0]],
    #         {
    #             "__username": "PeroPeric",
    #             "__table": "recive",
    #             "__key": "ovoSeNekakoPamti!"
    #         }
    #     )

    pass

    p = os.path.join(os.getcwd(), "cript.in")

    with open(p) as f:
        lines = f.read()

        queries = lines.split("\n\n")

        to_p = []

        is_first = True
        for i in queries:

            if is_first:
                is_first = False

            else:
                to_p.append("")

            to_p.append("await db_index.crypto_query_wrapper(")

            to_do = i.split("\n")
            # to_p.append(f"\t'{to_do[0]}',")

            # to_d = to_do[0].split(" ")

            # to_app = ""
            to_p.append(f"\t'{to_do[0]}',")

            u = to_do[1].split(": ")[1]
            k = to_do[2].split(": ")[1]
            t = to_do[0].split(" ")[2].lower()

            tmp = "["
            for j in to_do[3:]:
                if j == "":
                    continue

                j = j.split(": ")


                # as_j = json.loads('{"f": '+j[1]+'}')
                #
                # # t = {"t": j[1]}
                # # t = json.loads(str(t))
                # print(as_j["f"])
                tmp += "[\""+  j[0]+ "\", " +  j[1]+  "], "

            to_p.append(f"\t{tmp[:-2]}],")
            to_p.append("\t{")
            to_p.append(f"\t\t\"__username\": {u},")
            to_p.append(f"\t\t\"__table\": \"{t}\",")
            to_p.append(f"\t\t\"__key\": {k},")
            to_p.append("\t}")
            to_p.append(")")

        [print(i) for i in to_p]

        with open("cript.out", "w") as f_2:
            f_2.write("const db_index = require('./db_executor');" + "\n")
            f_2.write("(async () => {" + "\n")
            # const db_index = require('./db_executor');
            # (async () => {
            for i in to_p:
                f_2.write("\t"+i + "\n")
            f_2.write("})();" + "\n")

            # })();

            # f_2.write("module.exports = {")
            #
            # for i in const_names:
            #     f_2.write(f"\t{i},\n")
            #
            #     print(f"    query = await db_index.query(seed_insert.{i}, [])")
            #
            # f_2.write("}")

def main():
    # fill()
    generate_cript()

if __name__ == '__main__':
    main()
