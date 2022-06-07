import pycamunda.processinst
import pycamunda.task

url = 'http://localhost:8080/engine-rest'

get_instances = pycamunda.processinst.GetList(url,
                                              process_definition_key='Process_1bqcsp9')
instances = get_instances()

for instance in instances:
    print('Process instance id:', instance.id_)

    # pycamunda
    print(pycamunda.task.Get(instance.id_))