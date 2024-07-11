## Table: sys_user

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 自增主键 | int | int | 是 | 是 | nan | nan | nan | nan |
| user_id | 用户ID,六位数,从100000开始 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| user_name | 用户姓名 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| user_group | 用户组，默认default | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| user_type | 用户类型 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| avatar | 头像地址 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| password | 加密后密码 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| sso | 单点登录密码 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| last_login_ip | 最后登录地址 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| last_login_time | 最后登录时间 | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| status | 用户状态：在职、长假、产假、离职、调走 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | 0为未删除，1为已删除 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| data_id | nan | int | int | nan | nan | 是 | nan | nan | nan |
