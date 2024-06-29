# lims_list Table Schema

## Table: lims_list

| Column Name  | Description  | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|--------------|--------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id           | 主键         | int       | int         | Yes         | Yes            | No       |        |           |               |
| name         | 列表名称     | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| description  | 列表描述     | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| list_type    | 列表分类     | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| group_name   | 组名         | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| create_user  |              | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| create_time  |              | datetime  | DateTime    | No          | No             | Yes      |        |           |               |
| change_user  |              | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| change_time  |              | datetime  | DateTime    | No          | No             | Yes      |        |           |               |
| deleted      |              | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| data_id      |              | int       | int         | No          | No             | Yes      |        |           |               |
