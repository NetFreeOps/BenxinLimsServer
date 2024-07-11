## Table: sys_user_workflow

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 主键 | int | int | 是 | 是 | nan | nan | nan | nan |
| userid | 用户ID | int | int | nan | nan | 是 | nan | nan | nan |
| config_josn | 配置JSON文件 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| config_status | 配置状态（-1待发布，0禁用，1启用 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| data_id | nan | int | int | nan | nan | nan | nan | nan | nan |
