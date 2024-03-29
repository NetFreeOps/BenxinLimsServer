
### 功能描述

通过请求后台用户配置接口，将用户界面的配置文件加载到本地，然后根据这个文件界面，左侧列表要可以拖动，直接拖动到右侧主要部分，左侧先建立大类，然后拖动建立小类，并排序

### 输入参数

用户id，角色id


### 配置文件格式
`const userWorkFlow = ref([{
    "id": 1,
    "orderNum": 1,
    "type": "登记模板",
    "name": "成品登记",
    "backgroundColor": "#f0f0f0",
    "icon": "path/to/main/icon.png",
    "programName": "My Application"
}, {
    "id": 1,
    "orderNum": 1,
    "type": "登记模板",
    "name": "原油登记",
    "backgroundColor": "#f0f0f0",
    "icon": "path/to/main/icon.png",
    "programName": "My Application"
}, {
    "id": 1,
    "orderNum": 1,
    "type": "登记模板",
    "name": "辅料登记",
    "backgroundColor": "#f0f0f0",
    "icon": "path/to/main/icon.png",
    "programName": "My Application"
}, {
    "id": 1,
    "orderNum": 1,
    "type": "样品管理",
    "name": "接收样品",
    "backgroundColor": "#f0f0f0",
    "icon": "path/to/main/icon.png",
    "programName": "My Application"
}, {
    "id": 1,
    "orderNum": 1,
    "type": "样品管理",
    "name": "录入结果",
    "backgroundColor": "#f0f0f0",
    "icon": "path/to/main/icon.png",
    "programName": "My Application"
}, {
    "id": 1,
    "orderNum": 1,
    "type": "样品管理",
    "name": "审核结果",
    "backgroundColor": "#f0f0f0",
    "icon": "path/to/main/icon.png",
    "programName": "My Application"
}])`

### 文件解析
```js
 pageComponent.value = Object.values(userWorkFlow.value.reduce((acc, item) => {
        if (!acc[item.type]) {
            acc[item.type] = { type: item.type, items: [] };
        }
        acc[item.type].items.push({
            id: item.id,
            orderNum: item.orderNum,
            name: item.name,
            backgroundColor: item.backgroundColor,
            icon: item.icon,
            programName: item.programName,
        });
        return acc;
    }, {}));
```
### 步骤说明
1. 将配置文件按照orderNum排序
2. 将配置文件按照type分类组合
3. 从服务器加载可用组件信息
4. 从服务器加载可用可用程序信息
5. 通过图标选择组件选择图标
6. 通过程序选择组件选择程序`程序选择组件必须能够支持调试，对于高危行为比如update没有where条件要及时阻止`



