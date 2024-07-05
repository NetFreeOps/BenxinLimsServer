# Analysis Item Table Schema

## Table: analysis_item

| Column Name        | Description            | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value | Character Set | Collation        | Key Length | Key Order | Update with Current Timestamp | Binary | Unsigned | Zero Fill |
|--------------------|------------------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|---------------|------------------|------------|-----------|-------------------------------|--------|----------|-----------|
| id                 | 主键                   | int       | int         | Yes         | Yes            | No       | 11     |           |               |               |                  | 0          | ASC       | false                         | false  | false    | false     |
| analysis_id        | 分析表主键             | int       | int         | No          | No             | Yes      | 11     |           | NULL          |               |                  |            |           | false                         | false  | false    | false     |
| analysis_name      | 分析表分析名           | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| name               | 名称                   | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| version            | 版本                   | int       | int         | No          | No             | Yes      | 11     |           | 1             |               |                  |            |           | false                         | false  | false    | false     |
| order_number       | 排序                   | int       | int         | No          | No             | Yes      | 11     |           | NULL          |               |                  |            |           | false                         | false  | false    | false     |
| result_type        | 结果类型               | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| units              | 单位                   | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| min_value          | 最小值，默认空         | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| max_value          | 最大值，默认空         | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| places             | 重复数                 | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| auto_calc          | 自动计算               | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| common_name        | 通用名                 | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| nullable           | 可为空                 | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| reportable         | 可报告                 | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| list_key           | 列表型结果列表键       | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| calc_rule          | 计算规则，公式         | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| common_calc_rule   | 通用计算规则，最后生效 | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| round_rule         | 修约规则               | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| group_name         | 组名                   | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| create_user        |                       | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| create_time        |                       | datetime  | datetime    | No          | No             | Yes      |        |           | NULL          |               |                  |            |           | false                         | false  | false    | false     |
| change_user        |                       | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| change_time        |                       | datetime  | datetime    | No          | No             | Yes      |        |           | NULL          |               |                  |            |           | false                         | false  | false    | false     |
| deleted            |                       | varchar   | string      | No          | No             | Yes      | 255    |           | NULL          | utf8          | utf8_general_ci  |            |           | false                         | false  | false    | false     |
| data_id            |                       | int       | int         | No          | No             | Yes      | 11     |           | NULL          |               |                  |            |           | false                         | false  | false    | false     |