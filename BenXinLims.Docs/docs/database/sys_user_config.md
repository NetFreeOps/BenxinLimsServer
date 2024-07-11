## Table: sys_user_config

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 主键 | int | int | 是 | 是 | nan | nan | nan | nan |
| user_id | 用户工号，关联sys_user | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| config_type | 配置类型 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| config_field | 配置字段名 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| config_value | 配置字段值 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| status | 状态 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | 0为未删除，1为已删除 | varchar | string | nan | nan | 是 | 10.0 | nan | nan |
| data_id | 数据权限 | int | int | nan | nan | 是 | nan | nan | nan |
