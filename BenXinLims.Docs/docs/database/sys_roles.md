## Table: sys_roles

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | nan | int | int | 是 | nan | nan | nan | nan | nan |
| role_code | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| role_name | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | 0为未删除，1为已删除 | varchar | string | nan | nan | 是 | 10.0 | nan | 0.0 |
| data_id | 数据权限 | int | int | nan | nan | 是 | nan | nan | nan |
