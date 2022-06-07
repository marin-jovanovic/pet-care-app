import json

import requests

def create_process():
    url = 'https://www.w3schools.com/python/demopage.php'
    k = "Process_1bqcsp9u"

    url = "http://localhost:8080/engine-rest/process-definition/key/Process_1bqcsp9/start"

    # url = f"http://localhost:8080/engine-rest/process-definition/default/{k}/start"
    # myobj = {'somekey': 'somevalue'}
    myobj = {}
    # x = requests.post(url, data = myobj)

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers)
    # print(x.text)
    parsed = json.loads(x.text)
    print(json.dumps(parsed, indent=4, sort_keys=True))

    # import subprocess
    #
    # result = subprocess.run(
    #     ['curl -H "Content-Type: application/json" -X POST http://localhost:8080/engine-rest/process-definition/key/Process_1bqcsp9/start'],
    #     capture_output=True,
    #     text=True
    # )
    #
    # lines = result.stdout.split("\n")
    #
    # print(lines)

    return parsed["id"]

def get_tasks(processInstanceIdIn):
    new_id = "7b800189-e63e-11ec-84d0-0242ac110002"

    url = f"http://localhost:8080/engine-rest/task"
    # url = f"http://localhost:8080/engine-rest/task?processInstanceIdIn={processInstanceIdIn}&withoutTenantId=false&includeAssignedTasks=false&assigned=false&unassigned=false&withoutDueDate=false&withCandidateGroups=false&withoutCandidateGroups=false&withCandidateUsers=false&withoutCandidateUsers=false&active=false&suspended=false&variableNamesIgnoreCase=false&variableValuesIgnoreCase=false"

    data = {"processInstanceIdIn": processInstanceIdIn}
    # url = "http://localhost:8080/engine-rest/task"

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers)
    # print(x.text)
    parsed = json.loads(x.text)
    # print(json.dumps(parsed, indent=4, sort_keys=True))

    user_task_id = []
    for i in parsed:
        user_task_id.append((i["id"], i["name"]))
    # print(user_task_id)
    [print(i) for i in user_task_id]

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

def complete_task(task_id):

    url = f"http://localhost:8080/engine-rest/task/{task_id}/complete"
          # f"processInstanceIdIn={processInstanceIdIn}&withoutTenantId=false&includeAssignedTasks=false&assigned=false&unassigned=false&withoutDueDate=false&withCandidateGroups=false&withoutCandidateGroups=false&withCandidateUsers=false&withoutCandidateUsers=false&active=false&suspended=false&variableNamesIgnoreCase=false&variableValuesIgnoreCase=false"

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers)
    # parsed = json.loads(x.text)
    # print(json.dumps(parsed, indent=4, sort_keys=True))
    #
    # user_task_id = []
    # for i in parsed:
    #     user_task_id.append(i["id"])
    # # print(user_task_id)
    # [print(i) for i in user_task_id]


def main():
    # p = get_processes()
    p_selected = "8bfb216f-e63c-11ec-84d0-0242ac110002"

    tasks = get_tasks(p_selected)

    # t = tasks

    task_id = tasks[-1][0]
    print(task_id)

    complete_task(task_id)


        #
    # url = f"http://localhost:8080/engine-rest/task/{task_id}/complete"
    #
    # data = {"variables": {}}
    # # data = {
    # #   "ReviewAdlisting": "f"
    # # }
    # headers = {'Content-type': 'application/json'}
    # x = requests.post(url, headers=headers, data=data)
    # print(x.text)

    # parsed = json.loads(x.text)
    # # print(json.dumps(parsed, indent=4, sort_keys=True))
    #
    # user_task_id = []
    # for i in parsed:
    #     user_task_id.append(i["id"])
    # # print(user_task_id)
    # [print(i) for i in user_task_id]


    # new_id = init()
    # new_id = "7b800189-e63e-11ec-84d0-0242ac110002"
    #
    # get_tasks(new_id)

    # complete_task("fab08abc-e63d-11ec-84d0-0242ac110002")


if __name__ == '__main__':
    # main()

    task_id = "77e575a8-e63e-11ec-84d0-0242ac110002"
    #
    # url = f"http://localhost:8080/engine-rest/task/{task_id}/complete"
    # data = {"variables": {}}
    # headers = {'Content-type': 'application/json'}
    # x = requests.post(url, headers=headers, data=data)
    # print(x.text)
    #
    #
    url = f"http://localhost:8080/engine-rest/message"
    #       # f"processInstanceIdIn={processInstanceIdIn}&withoutTenantId=false&includeAssignedTasks=false&assigned=false&unassigned=false&withoutDueDate=false&withCandidateGroups=false&withoutCandidateGroups=false&withCandidateUsers=false&withoutCandidateUsers=false&active=false&suspended=false&variableNamesIgnoreCase=false&variableValuesIgnoreCase=false"
    #
    data = {
        "messageName": "ReviewAdlisting",
        "processInstanceId": "8bfb216f-e63c-11ec-84d0-0242ac110002"
    }

    data = json.dumps(data)
    # data = "ReviewAdlisting"
    # data = {"messageName" : "ReviewAdlisting",
    #     "businessKey" : "aBusinessKey",
    #     "correlationKeys" : {
    #         "aVariable" : {"value" : "aValue", "type": "String"}
    #     },
    #     "processVariables" : {
    #         "aVariable" : {"value" : "aNewValue", "type": "String"},
    #         "anotherVariable" : {"value" : True, "type": "Boolean"}
    #     }
    # }

    headers = {'Content-type': 'application/json'}
    x = requests.post(url, headers=headers, data=data)
    print(x.text)
    # parsed = json.loads(x.text)
    # # print(json.dumps(parsed, indent=4, sort_keys=True))
    #
    # user_task_id = []
    # for i in parsed:
    #     user_task_id.append(i["id"])
    # # print(user_task_id)
    # [print(i) for i in user_task_id]






    # import pycamunda.processinst
    #
    # url = 'http://localhost:8080/engine-rest'
    #
    # get_instances = pycamunda.processinst.GetList(url,
    #                                               process_definition_key='Process_1bqcsp9')
    # instances = get_instances()
    #
    # for instance in instances:
    #     print('Process instance id:', instance.id_)
    #
    #     tasks = pycamunda.GetList()
    #     print(tasks)