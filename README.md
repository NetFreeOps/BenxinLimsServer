# BenxinLimsServer

## 各种表
> #### 样品表
> #### 样品模板表
> #### 样品模板分项表
> #### 样品留样信息表
> #### 检测表
> #### 结果表
> #### 样品审计表
> #### 操作审计表
> #### 产品表
> #### 产品登记表
> #### 检测单表
> #### 检测单项目表
> #### 分析表
> #### 分析分项表
> #### 字典表
> #### 字典分项表
> #### 用户表（登录用）
> #### 采样点表
> #### 岗位表
> #### 装置表
> #### 设备表
> #### 设备分析对应表
> #### 设备人员对应表
> #### 岗位人员对应表
> #### 文件信息表
> #### 样品文件表
> #### 检测文件表
> #### 用户文件表

## 样品部分

样品登记，接收，分样，留样，各级审核
> ### 样品登记
> 需要有个样品等级模板，模板中的每个字段类型都可以自定义，如果是列表型的要可以选择一个字典（调用字典选择函数）
> 样品登记后要肯定要有个回调，有一系列的检查程序，回调通知程序
> 样品登记要有日志程序
> 自动调度登记，那就需要有个自动调度的模板，可以配置自动调度规则
> 样品登记函数要保留注入口，或者可以链式调用，或者可以允许加载一个或多个自定义函数

### 样品登记部分

样品登记模板，自动调度登记

### 样品接收部分

接收后自动处理，手动接收，自动接收，条件接收

### 分样

自动，手动分样

### 留样

登记时自动添加子样品，留样编号，子样品编号建立关联关系

### 各级审核

直接将审核字段写到样品表中，添加审核日志

## 人员部分

基本信息，培训，证书管理（上岗证），工作量，岗位，分组，实验室（三级权限分配，实验室最大，岗位最小）

## 设备部分

设备基本信息，设备自动采集信息，采购信息，说明书等资料信息，维修信息，设备-分析关联，设备鉴定信息

## 分析部分

分析方法基本信息，分项信息，计算信息，单位换算信息

## 产品部分

产品信息，产品指标信息

## 内置函数部分

内置函数应该可以通过JS调用？

> 1. 样品登记函数
> 2. 样品接收函数
> 3. 字典选择函数

## 二次开发信息

1、各种自己开发的程序，对接到系统的各个方面
2、要有这样一个函数，这个函数有一个入参`函数名`,另外的参数就是这个函数所具有的参数，然后要有一个返回
3、有些函数可以放在服务器调用，有些函数可以放在客户端调用，做好区分


## 系统信息

在LIMS系统中，结果表是一个大表，需要给样品、检测、结果三个表单独建立表空间
审计表是一个会急剧增加的表，也需要单独建立表空间

## 权限划分

LIMS系统的权限和普通的后台管理的权限有所不同，不仅要有页面的权限，还要有页面中按钮的权限，
系统中的角色决定了页面、按钮的权限，而岗位决定了数据权限，所有最终展示的样品数据都要经过用户岗位的筛选。
系统管理员可以具有所有岗位
系统最高权限账号应该固化到配置里或者代码里，这样只有拿到后台服务器部署权限的人才能更改密码

## 需要一个模板

这个模板要可以让用户自定义，类似代码生成器，既然这样，就要有个文件夹存放这些自定义生成的模板，然后前台要有个方法调用。
修改后要能保存历史数据（配置信息可以放到数据库中，但是具体生成的前端文件要存到服务器并可以调用。
或者直接做一个通用的页面，用来根据配置文件加载。

## 日志系统

1 日志要分类，样品日志、登记日志、审核日志、录入日志等
2 日志要可以配置，日志系统就是后期的审计系统，要可以让用户配置启用什么日志，是保存到数据库还是以文件的形式保存到本地 
如果保存到本地，一定要有一个可以加载的界面。

## 报表系统

报表系统开发起来太过于繁琐，就直接集成一个免费开源的报表系统凑合着用，真要是大企业就直接用帆软了

----------------------------------------------------------------
## 主要工作流程

> ### 样品流程
> #### 样品登记
> 打开样品登记模板，录入样品信息，点击登录按钮登录。调用一系列函数
>
## 开发流程

> 1、先建立分析项目、检测单、产品、采样点、装置层级、人员、岗位
> 2、建立样品登记模板、样品模板编辑功能

## 数据库
> 数据库就直接用mysql；
> 所有字典命名采用下划线链接
> 所有数据库表都有description、change_on、change_by、deleated
> 提前规划好主键、外键但是不用数据库的外键约束
> 所有主键一定是无意义的自增数字
------------------------------------------------------

## 文档部分
文档采用vuepress，明天开始搭建文档
文档可能要换了，vuepress2对中文目录支持不好，并且对文件夹层次支持也不好

