from hierarchy import *


def serialize(lst: list):
    with open('File.txt', 'w') as f:
        for obj in lst:
            Dryopithecus = vars(obj)
            cls = Dryopithecus.get('_who')
            f.writelines('{' + '\'' + str(cls) + '\'' + ': ' + str(Dryopithecus) + '}' + '\n')


def deserialize():
    lst = []
    with open('File.txt', 'r') as f:
        Lines = f.readlines()
    classes = []

    for line in Lines:
        classes.append(line.strip())

    for cls in classes:
        s = str(cls)
        ss = s[2:]
        pos = ss.find(':')
        who = ss[:pos]
        who = who.replace('\'', '')
        print(who)

        newClass = type(who, (), {})

        pos1 = ss.find('{')
        ss = ss[pos1:]
        ss = ss.replace('\'', '')
        ss = ss.replace('{', '')
        ss = ss.replace('}', '')

        convertedDict = dict((x.strip(), y.strip())
                             for x, y in (element.split(':')
                                          for element in ss.split(', ')))

        newClass.physical = convertedDict['_physical']
        newClass.name = convertedDict['_name']
        newClass.age = convertedDict['_age']
        lst.append(newClass)

    return lst


if __name__ == '__main__':
    lst = []
    objects = {1: Monkey(), 2: Dryopithecus(),
               3: Australopithecus(), 4: Pithecanthropus(),
               5: Neanderthal(), 6: CroMagnon(),
               7: Contemporaneous()}

    print('1.Add     2.Load      3.Delete     4.Edit      5.Save      6.Exit')
    x = int(input())

    while x != 6:
        if x == 1:
            print(
                '1.Monkey       2.Dryopithecus      3.Australopithecus      4.Pithecanthropus       '
                '5.Neanderthal       6.CroMagnon     7.Contemporaneous')
            per = int(input())
            for item in objects:
                if item == per:
                    lst.append(objects[item])

        elif x == 2:
            lst = deserialize()

        elif x == 3:
            print('Enter object number:')
            obj = int(input())
            if lst[obj]:
                del lst[obj]

        elif x == 4:
            print('Enter object number:')
            obj = int(input())
            if lst[obj]:
                print(vars(lst[obj]))
                print('1.Age     2.Name      3.Physical (Outfit)')
                num = int(input())

                if num == 1:
                    print('Enter new age:')
                    age = int(input())
                    lst[obj].age = age

                elif num == 2:
                    print('Enter new name:')
                    name = input()
                    lst[obj].name = name

                elif num == 3:
                    print('Enter new physical(outfit):')
                    physical = input()
                    lst[obj].physical = physical

            elif x == 5:
                serialize(lst)

        print('1.Add     2.Load      3.Delete     4.Edit      5.Save      6.Exit')
        # print(lst)
        x = int(input())

    serialize(lst)
    exit(0)
