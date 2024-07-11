## Table: analysis_calc

| Column Name | Description | Data Type | Entity Type | Primary Key | Auto Increment | Nullable | Length | Precision | Default Value |
|-------------|-------------|-----------|-------------|-------------|----------------|----------|--------|-----------|---------------|
| id | 主键 | int | int | 是 | 是 | nan | nan | nan | nan |
| analysis_id | 分析表主键 | int | int | nan | nan | 是 | nan | nan | nan |
| analysis_item_id | 分析分项表主键 | int | int | nan | nan | 是 | nan | nan | nan |
| version | 版本 | int | int | nan | nan | 是 | nan | nan | nan |
| source_code | 源码 | text | string | nan | nan | 是 | nan | nan | nan |
| create_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| create_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| change_user | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| change_time | nan | datetime | DateTime | nan | nan | 是 | nan | nan | nan |
| deleted | nan | varchar | string | nan | nan | 是 | 200.0 | nan | nan |
| data_id | nan | int | int | nan | nan | 是 | nan | nan | nan |
