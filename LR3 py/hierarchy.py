class Monkey:
    def __init__(self):
        super().__init__()
        self._who = 'Monkey'
        self._name = None
        self._age = None
        self._physical = None

    def get_age(self) -> str:
        return self._age

    def set_age(self, a):
        self._age = a

    def del_age(self):
        del self._age

    def get_name(self) -> str:
        return self._name

    def set_name(self, n):
        self._name = n

    def del_name(self):
        del self._name

    def get_who(self):
        return self._who

    def get_physical(self) -> str:
        return self._physical

    def set_physical(self, s):
        self._physical = s

    def del_physical(self):
        del self._physical

    age = property(get_age, set_age, del_age)

    name = property(get_name, set_name, del_name)

    who = property(get_who)

    salary = property(get_physical, set_physical, del_physical)


class Dryopithecus(Monkey):
    def __init__(self):
        super().__init__()
        self._who = 'Dryopithecus'


class Australopithecus(Dryopithecus):
    def __init__(self):
        super().__init__()
        self._who = 'Australopithecus'


class Pithecanthropus(Australopithecus):
    def __init__(self):
        super().__init__()
        self._who = 'Pithecanthropus'


class Neanderthal(Pithecanthropus):
    def __init__(self):
        super().__init__()
        self._who = 'Neanderthal'


class CroMagnon(Neanderthal):
    def __init__(self):
        super().__init__()
        self._who = 'CroMagnon'


class Contemporaneous(Neanderthal):
    def __init__(self):
        super().__init__()
        self._who = 'Contemporaneous'

#Monkey - Dryopithecus, Australopithecus, Pithecanthropus, Neanderthal, CroMagnon, Contemporaneous