
//立即执行函数  转变表达式
(function () {
    var root = this; //这里的this就是window对象了。

    var previousUnderscore = root._;

    var ArrayProto = Array.prototype, ObjProto = Object.prototype, FuncProto = Function.prototype;//每一个函数对象都有一个显示 的prototype属性，它代表了对象的原型(Function.Prototype是个例外，它没有prototype属性)

    var push = ArrayProto.push,
        slice = ArrayProto.slice,
        toString = ObjProto.toString,
        hasOwnProperty = ObjProto.hasOwnProperty;

    var nativeIsArray = Array.isArray,
        nativeKeys = Object.keys,
        nativeBind = FuncProto.bind,
        nativeCreate = Object.create;

    var Ctor = function () { };

    var _ = function (obj) {
        if (obj instanceof _) return obj;//instanceof 用于判断一个变量是否是某个对象的实例
        if (!(this instanceof _)) return new _(obj);
        this._wrapped = obj;
    }

    if (typeof exports != "undefined")//typeof 返回的是一个字符串 用于说明运算符的类型
    {
        if (typeof module != "undefined" && module.exports)
            exports = module.exports = _;
        exports._ = _;
    } else
        root._ = _;

    _.VERSION = '1.7.0';

    var optimizeCb = function (func, context, argCount) {
        if (context == void 0) return func;
        switch (argCount == null ? 3 : argCount) {
            case 1: return function (value) {
                return func.call(context, value);
            };
            case 2: return function (value, other) {
                return func.call(context, value, other);
            };
            case 3: return function (value, index, collection) {
                return func.call(context, value, index, collection);
            };
            case 4: return function (accumulator, value, index, collection) {
                return func.call(context, accumulator, value, index, collection);
            };
        }
        return function () {
            return func.apply(context, arguments);
        };
    }

    var cb = function (value, context, argCount) {
        if (value == null) return _.identity;
        if (_.isObject(value)) return _.matches(value);
        return _.property(value);
    }
    _.iteratee = function (value, context) {
        return cb(value, context, Infinity);
    };

    _.identity = function (value) {
        return value;
    }

    var createAssigner = function (keysFunc) {
        return function (obj) {
            var length = arguments.length;//获取参数的个数
            if (length < 2 || obj == null) return obj;

            for (var index = 0; index < length; index++) {
                var source = arguments[index]; //参数
                keys = keysFunc(source);
                l = keys.length;
                for (var i = 0; i < l; i++) {
                    var key = keys[i];
                    obj[key] = source[key];
                }
            }
            return obj;
        }
    }

    var baseCreate = function(prototype)
    {
        if (!_.isObject(prototype)) return {};
        if (nativeCreate) nativeCreate(prototype);
        Ctor.prototype = pro
    }
})