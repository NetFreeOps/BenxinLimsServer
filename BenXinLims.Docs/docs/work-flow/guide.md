
### 功能描述

通过请求后台用户配置接口，将用户界面的配置文件加载到本地，然后根据这个文件界面

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

1. 将配置文件按照orderNum排序
2. 将配置文件按照type分类组合
