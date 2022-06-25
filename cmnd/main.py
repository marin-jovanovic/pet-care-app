import json
import time

import requests

def create_process():
    url = 'https://www.w3schools.com/python/demopage.php'
    k = "Process_1bqcsp9u"

    url = "http://localhost:8080/engine-rest/process-definition/key/Process_1bqcsp9/start"

    p = {}
    # p = {
    #   "variables": {
    #   #   "amount": {
    #   #   "value": 30,
    #   #   "type": "Double"
    #   #   },
    #   #   "creditor": {
    #   #   "value": "Niall",
    #   #   "type": "String"
    #   #   },
    #   # "invoiceCategory": {
    #   #   "value": "Travel Expenses",
    #   #   "type": "String"
    #   #   },
    #   # "invoiceNumber": {
    #   #   "value": "BER-00001",
    #   #   "type": "String"
    #   #   },
    #
    #     # "Admin": "admin1"
    #   },
    #   # "businessKey": "Doom1",
    #   # "withVariablesInReturn": True
    # }

    p = {
        "variables": {
            "Admin": {
                "value": None,
                # "value": "admin2",
                "type": "String"
            },
            "RevievNeeded": {
                "value": None,
                "type": "Boolean"
            },
            "advertisement": {
                "value": None,
                "type": "Integer"
            }
        }
    }

    p = json.dumps(p)

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers, data=p)
    parsed = json.loads(x.text)
    print(json.dumps(parsed, indent=4, sort_keys=True))


    return parsed["id"]

def get_tasks(processInstanceIdIn):

    url = f"http://localhost:8080/engine-rest/task"

    data = {"processInstanceId": processInstanceIdIn}
    data = json.dumps(data)

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers, data=data)
    parsed = json.loads(x.text)
    # print(json.dumps(parsed, indent=4, sort_keys=True))

    user_task_id = []
    for i in parsed:
        user_task_id.append((i["id"], i["name"]))

    return user_task_id

def get_processes():
    new_id = "7b800189-e63e-11ec-84d0-0242ac110002"

    url = f"http://localhost:8080/engine-rest/process-instance"
    # url = "http://localhost:8080/engine-rest/task"

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers)
    # print(x.text)
    parsed = json.loads(x.text)
    # print(json.dumps(parsed, indent=4, sort_keys=True))
    #
    user_task_id = []
    for i in parsed:
        user_task_id.append(i["id"])
    # print(user_task_id)
    print("processes")
    [print(i) for i in user_task_id]
    # print()
    return user_task_id

def user_report_ad_listing(task_id):

    url = f"http://localhost:8080/engine-rest/task/{task_id}/complete"

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers)
    print(x.text)

def admin_review_ad_listing(t, task_id):
    if t == "yes":
        data = {
            "variables": {
                "RevievNeeded": {
                    "value": False,
                    "type": "Boolean"
                },
                "advertisement": {
                    "value": 0,
                    "type": "Integer"
                }
            }

        }
    else:
        data = {
            "variables": {
                "RevievNeeded": {
                    "value": True,
                    "type": "Boolean"
                },
                "advertisement": {
                    "value": 1,
                    "type": "Integer"
                }
            }
        }

    data = json.dumps(data)

    url = f"http://localhost:8080/engine-rest/task/{task_id}/complete"
    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers, data=data)
    print(x.text)


def main():
    p = "73bc7184-e67e-11ec-8364-0242ac110002"
    p = None
    if not p:
        p = create_process()
        print(f"created process {p}")

    print(f"using {p} as process\n")

    # tasks = get_tasks(p)
    task = get_tasks(p)[-1][0]
    print("task")
    print(task)
    print()

    print("USER: report")
    user_report_ad_listing(task)

    print("ADMIN: review")
    admin_accept_review(p)

    task = get_tasks(p)
    print("task")
    print(task)
    print()
    time.sleep(1)
    task = task[-1][0]

    t = input("ADMIN: do you want to delete ad listing?")
    admin_review_ad_listing(t, task)



def admin_accept_review(processInstanceId):

    url = f"http://localhost:8080/engine-rest/message"

    data = {
        # "variables": {
        #     "Admin": "admin1"
        # },

        "variables": {
            "Admin": {
                # "value": None,
                "value": "admin1",
                "type": "String"
            }
        },

        "messageName": "ReviewAdlisting",
        "processInstanceId": processInstanceId
    }

    data = json.dumps(data)

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers, data=data)
    print(x.text)

if __name__ == '__main__':
    main()
