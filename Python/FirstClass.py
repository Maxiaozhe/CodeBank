import os
import sys
import inspect
import enum
import io
import string
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
        self.instance = obj
        pass

    #
    @property
    def methods(self):
        mems = [m for m in inspect.getmembers(self.instance)]
        methods = []
        for m in mems:
            if self.ismethod(m[1]):
                methods.append(m)
        return methods

    @property
    def fields(self):
        mems = [m for m in inspect.getmembers(self.instance)]
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


def main():
    # tp = typeinfo(os.sys)
    # print(tp.__dir__())
    modules= typeinfo.getmodules()
    lst= list( map(lambda x:"{0} : {1}".format(x[0], x[1]),sorted(modules.items(), key=lambda x:x[0])))
    for m in lst:
        print(m)
    m=module()
main()
