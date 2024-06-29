# LIMS List Item Table Schema

## Table: lims_list_item

| Column Name | Description        | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|--------------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id          |                    | int       | int         | Yes         | Yes            | No       |        |           |               |
| list_id     | lims_list表的主键 | int       | int         | No          | No             | Yes      |        |           |               |
| name        | 显示值             | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| value       | 储存值             | varchar   | string      | No          | No             | Yes      | 200    |           |               |
| order       | 排序               | varchar   | string      | No          | No             | Yes      | 200    |           |               |
