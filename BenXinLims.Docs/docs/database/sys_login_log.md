## Table: sys_login_log

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 主键 | int | int | 是 | nan | nan | nan | nan | nan |
| userid | 用户id,取工号 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| username | 用户姓名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| success | 是否登录成功，成功为1 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| message | 登录消息 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| ip | ip地址 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| location | 登录位置 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| browser | 浏览器 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| os | 系统 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| vis_type | 登录类型 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| vis_time | 登录时间 | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | 0为未删除，1为已删除 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| data_id | nan | int | int | nan | nan | 是 | nan | nan | nan |
