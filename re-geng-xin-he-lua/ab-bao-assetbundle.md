# AB包(AssetBundle)

## AB包是什么

简而言之,ab包是压缩文件。是热更新的基石。

## AB包的作用

1. 相对于Resources下的资源，AB包更好管理资源。Resources打包时定死，只读，无法修改。而AB包存储位置可自定义，压缩方式可自定义，后期可以动态更新。
2. 压缩资源，减少初始包大小。
3. 热更新。包含资源热更新和脚本热更新。

## 热更新流程

1.版本号比较，如果版本号不同才继续下面的流程（可选，也可以直接下载）

2.下载对比文件，下载资源服务器上的的对比文件

3.对比，用下载的文件和本地文件对比，记录改变的和新增的

4.下载资源，下载刚才记录的文件——一般放在Application.persistentDataPath

5.解压（可选）——如果文件是压缩过的，要先解压

6.覆盖本地对比文件；保证下载成功后 将下载的对比文件 覆盖本地的

## 对比文件常用技术

MD5码对比

## **AB包资源加载和Resources资源加载有什么区别？**

\
1.API不同

2.Resources加载的资源 一定得放在Resources文件夹下\
AB包理论上来说放在任何地方都可以 但一般都放在Application.streamingAssetsPath或Application.persistentDataPath

3.AB包中是资源集合，Resources下都是单个资源

## **AB包对于我们来说有什么作用？**

减少包体大小：因为打AB可以选择压缩，压缩后可以有效减少包体大小

Unity中热更新的基础：我们会把资源、Lua脚本打包成AB包，用于热更新
