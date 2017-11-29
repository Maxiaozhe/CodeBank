import os
import sys
import inspect
import enum
import io
import types

'''
取得对象的详细属性和方法的类
'''

# #函数的列举类型
# class methodtype(enum):
#     function = 'Function'
#     builtin = 'Builtin Function'
#     lambda_func='lambda Function'

# 对象类型的详细属性
class typeinfo(object):
    def __init__(self, obj):
        self._instance = obj
        pass

    #
    @property
    def methods(self):
        mems = [m for m in inspect.getmembers(self._instance)]
        methods = []
        for m in mems:
            if self.ismethod(m[1]):
                methods.append(m)
        return methods

    @property
    def fields(self):
        mems = [m for m in inspect.getmembers(self._instance)]
        fields = []
        for field in mems:
            if not inspect.ismethod(field):
                fields.append(field)
        return fields

    def ismethod(self, obj):
        return callable(obj) or inspect.ismethod(obj) or inspect.isfunction(obj) or inspect.isbuiltin(obj)

    def _customfunction(self):
        pass

    def __dir__(self):
        sb = ""
        sb += "-------------------Methods--------------------------\n"
        for method in self.methods:
            sb += str(method[0]) + "\n"
        fmt = "名字：{0}            值:{1}\n"
        sb += "-------------------Fields--------------------------\n"
        for field in self.fields:
            value = field[1]
            if value is None:
                value = "None"
            sb += fmt.format(field[0], value)
        return sb

    @staticmethod
    def getmodules():
        return sys.modules


def format(m,offset=""):

    buff = ""
    if isinstance(m,types.ModuleType):
        buff +=  m.__name__ + "  ::  module \n"
        # buff += "\t" + m.__doc__ + "\n"
        buff += "\t" + format(m.__dict__)
    elif isinstance(m, dict):
        lst = m.items()
        if len(offset)==0:
            lst = sorted(m.items(), key=lambda x: x[0])
        for dic in lst:
            if isinstance(dic[1], dict) and len(offset) <=1:
                buff += offset + "\t\t" + dic[0] + " :: " + format(dic[1],"\t" + offset) + "\n"
            else:
                buff += offset + "\t\t" + str(dic) + "\n"
    elif isinstance(m,type):
        buff += str(m)
    elif isinstance(m,object):
        buff += str(m)
    else:
        buff += str(m)
    return buff


def main():
    # tp = typeinfo(os.sys)
    # print(tp.__dir__())
    limit = sys.getrecursionlimit()
    sys.setrecursionlimit(2000)
    modules = typeinfo.getmodules()
    lst = list(map(lambda x: format(x[1]),
                   sorted(modules.items(), key=lambda x: x[0])))
    for m in lst:
        print(m)
    file =open(r"c:\\python_modules.txt","wb")
    for line in lst:
        file.write(line.encode())
    file.close()

main()
