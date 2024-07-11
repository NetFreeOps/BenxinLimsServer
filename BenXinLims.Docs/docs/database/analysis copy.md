## Table: analysis

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 自增主键 | int | int | 是 | nan | nan | nan | nan | nan |
| name | 分析名称，不能重复 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| version | 版本，默认1 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| group_name | 组名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| lab_name | 实验室名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| active | 是否激活 | int | int | nan | nan | nan | nan | nan | nan |
| report_name | 报告名称 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| common_name | 通用名称 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| analysis_type | 分析类型 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| description | 描述信息 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| default_post | 默认岗位 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| standard | 分析标准 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| file_link | 关联文件 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| data_id | nan | int | int | nan | nan | 是 | nan | nan | nan |
