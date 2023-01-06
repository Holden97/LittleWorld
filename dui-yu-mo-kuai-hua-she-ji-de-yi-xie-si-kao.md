# 对于模块化设计的一些思考

松耦合，高内聚

1.子物体不应引用父节点，应使用事件或者委托，例如，点击事件应通过注册回调（委托）的方式在父节点实现。

对象之间的四种交互方式

1.方法调用，A直接调用B的方法

2.委托/回调 A持有B，注册B中声明的委托，例如点击事件的监听

3.消息/事件 A,B之间不需要相互了解

4.Command



模块化一般也有三种

单例

IOC

分层 例如MVC，三层架构，领域驱动分层



交互逻辑

view->model

表现逻辑

model->view



成型的框架研究

PureMVC,StrangelOC,uFrame,.Net Core的DDD实现



数据是底层，表现是顶层



struct相比class有更好的内存管理效率

命令模式可以让逻辑的调用和执行在空间、时间都实现分离。



表现层到底层用Command

底层到表现层用委托/事件，游戏状态事件只能通过底层发送给表现层，反之不行

表现层能够查询数据，可以被替换。



参考资料

1. Unity 游戏框架搭建 决定版 [https://learn.u3d.cn/tutorial/framework\_design?chapterId=63562b29edca72001f21d172#](https://learn.u3d.cn/tutorial/framework\_design?chapterId=63562b29edca72001f21d172)

&#x20;