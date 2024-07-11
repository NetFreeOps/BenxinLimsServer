## Table: analysis_item

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 主键 | int | int | 是 | 是 | nan | nan | nan | nan |
| analysis_id | 分析表主键 | int | int | nan | nan | 是 | nan | nan | nan |
| analysis_name | 分析表分析名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| name | 名称 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| version | 版本 | int | int | nan | nan | 是 | nan | nan | 1.0 |
| order_number | 排序 | int | int | nan | nan | 是 | nan | nan | 1.0 |
| result_type | 结果类型 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| units | 单位 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| min_value | 最小值，默认空 | int | int | nan | nan | 是 | nan | nan | nan |
| max_value | 最大值，默认空 | int | int | nan | nan | 是 | nan | nan | nan |
| places | 重复数 | int | int | nan | nan | 是 | nan | nan | 1.0 |
| auto_calc | 自动计算 | int | int | nan | nan | 是 | nan | nan | 1.0 |
| common_name | 通用名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| nullable | 可为空 | int | int | nan | nan | 是 | nan | nan | 1.0 |
| reportable | 可报告 | int | int | nan | nan | 是 | nan | nan | 1.0 |
| list_key | 列表型结果列表键 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| calc_rule | 计算规则，公式 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| common_calc_rule | 通用计算规则，最后生效 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| round_rule | 修约规则 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| group_name | 组名 | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| data_id | nan | int | int | nan | nan | 是 | nan | nan | nan |
