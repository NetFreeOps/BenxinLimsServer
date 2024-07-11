## Table: process_unit

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 自增主键 | int | int | 是 | 是 | nan | nan | nan | nan |
| parent_id | 父装置ID，没有为0 | int | int | nan | nan | 是 | nan | nan | nan |
| name | 装置名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| code | 装置代码 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| active | 是否激活 | int | int | nan | nan | 是 | nan | nan | nan |
| template | 装置模板 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| alias_name | 别名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| work_shop | 所属公司 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| is_end | 是否是末端装置 | int | int | nan | nan | 是 | nan | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| data_id | nan | int | int | nan | nan | 是 | nan | nan | nan |
