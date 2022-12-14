# 抽象工厂模式

这个模式最不好理解，而且在实际应用中局限性也蛮大的，因为这个模式并不符合开闭原则。实际开发还需要做好权衡。\
　　抽象工厂模式是工厂方法的进一步深化，在这个模式中的工厂类不单单可以创建一个对象，而是可以创建一组对象。这是和工厂方法最大的不同点。

**定义：**\
　　提供一个创建一系列相关或相互依赖对象的接口，而无须指定它们具体的类。（ 在抽象工厂模式中，每一个具体工厂都提供了多个工厂方法用于产生多种不同类型的对象）\
　　\
抽象工厂和工厂方法一样可以划分为4大部分：\
AbstractFactory（抽象工厂）声明了一组用于创建对象的方法，注意是一组。\
ConcreteFactory（具体工厂）：它实现了在抽象工厂中声明的创建对象的方法，生成一组具体对象。\
AbstractProduct（抽象产品）：它为每种对象声明接口，在其中声明了对象所具有的业务方法。\
ConcreteProduct（具体产品）：它定义具体工厂生产的具体对象。\
下面还是先看一个具体实例。

**实例：**\
　　现在需要做一款跨平台的游戏，需要兼容Android，Ios，Wp三个移动操作系统，该游戏针对每个系统都设计了一套操作控制器（OperationController）和界面控制器（UIController），下面通过抽闲工厂方式完成这款游戏的架构设计。

由题可知，游戏里边的各个平台的UIController和OperationController应该是我们最终生产的具体产品。所以新建两个抽象产品接口。

抽象操作控制器

```csharp
public interface OperationController {
    void control();
}
```

抽象界面控制器

```csharp
public interface UIController {
    void display();
}
```

然后完成各个系统平台的具体操作控制器和界面控制器\
Android

```java
public class AndroidOperationController implements OperationController {
    @Override
    public void control() {
        System.out.println("AndroidOperationController");
    }
}

public class AndroidUIController implements UIController {
    @Override
    public void display() {
        System.out.println("AndroidInterfaceController");
    }
}
```

Ios

```java
public class IosOperationController implements OperationController {
    @Override
    public void control() {
        System.out.println("IosOperationController");
    }
}

public class IosUIController implements UIController {
    @Override
    public void display() {
        System.out.println("IosInterfaceController");
    }
}
```

Wp

```java
public class WpOperationController implements OperationController {
    @Override
    public void control() {
        System.out.println("WpOperationController");
    }
}
public class WpUIController implements UIController {
    @Override
    public void display() {
        System.out.println("WpInterfaceController");
    }
}
```

下面定义一个抽闲工厂，该工厂需要可以创建OperationController和UIController

```csharp
public interface SystemFactory {
    public OperationController createOperationController();
    public UIController createInterfaceController();
}
```

在各平台具体的工厂类中完成操作控制器和界面控制器的创建过程

Android

```java
public class AndroidFactory implements SystemFactory {
    @Override
    public OperationController createOperationController() {
        return new AndroidOperationController();
    }

    @Override
    public UIController createInterfaceController() {
        return new AndroidUIController();
    }
}
```

Ios

```java
public class IosFactory implements SystemFactory {
    @Override
    public OperationController createOperationController() {
        return new IosOperationController();
    }

    @Override
    public UIController createInterfaceController() {
        return new IosUIController();
    }
}
```

Wp

```java
public class WpFactory implements SystemFactory {
    @Override
    public OperationController createOperationController() {
        return new WpOperationController();
    }

    @Override
    public UIController createInterfaceController() {
        return new WpUIController();
    }
}
```

客户端调用：

```cpp
    SystemFactory mFactory;
    UIController interfaceController;
    OperationController operationController;

    //Android
    mFactory=new AndroidFactory();
    //Ios
    mFactory=new IosFactory();
    //Wp
    mFactory=new WpFactory();

    interfaceController=mFactory.createInterfaceController();
    operationController=mFactory.createOperationController();
    interfaceController.display();
    operationController.control();
```

针对不同平台只通过创建不同的工厂对象就完成了操作和UI控制器的创建。小伙伴们可以对比一下，如果这个游戏使用工厂方法模式搭建需要创建多少个工厂类呢？下面总结一下抽象工厂的适用场景。

**适用场景：**\
（1）和工厂方法一样客户端不需要知道它所创建的对象的类。\
（2）需要一组对象共同完成某种功能时。并且可能存在多组对象完成不同功能的情况。\
（3）系统结构稳定，不会频繁的增加对象。（因为一旦增加就需要修改原有代码，不符合开闭原则）

\
\
作者：Knight\_Davion\
链接：https://www.jianshu.com/p/83ef48ce635b\
来源：简书\
著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
