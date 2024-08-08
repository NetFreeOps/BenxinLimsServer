import{openBlock as t,createElementBlock as d,createStaticVNode as n}from"vue";import{_ as a}from"./app-Y3nPrZJQ.js";const r={},e=n('<h2 id="table-analysis-item" tabindex="-1"><a class="header-anchor" href="#table-analysis-item" aria-hidden="true">#</a> Table: analysis_item</h2><table><thead><tr><th>Column Name</th><th>Description</th><th>Data Type</th><th>Entity Type</th><th>Primary Key</th><th>Auto Increment</th><th>Nullable</th><th>Length</th><th>Precision</th><th>Default Value</th></tr></thead><tbody><tr><td>id</td><td>主键</td><td>int</td><td>int</td><td>是</td><td>是</td><td>nan</td><td>nan</td><td>nan</td><td>nan</td></tr><tr><td>analysis_id</td><td>分析表主键</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>nan</td></tr><tr><td>analysis_name</td><td>分析表分析名</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>name</td><td>名称</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>version</td><td>版本</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>1.0</td></tr><tr><td>order_number</td><td>排序</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>1.0</td></tr><tr><td>result_type</td><td>结果类型</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>units</td><td>单位</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>min_value</td><td>最小值，默认空</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>nan</td></tr><tr><td>max_value</td><td>最大值，默认空</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>nan</td></tr><tr><td>places</td><td>重复数</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>1.0</td></tr><tr><td>auto_calc</td><td>自动计算</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>1.0</td></tr><tr><td>common_name</td><td>通用名</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>nullable</td><td>可为空</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>1.0</td></tr><tr><td>reportable</td><td>可报告</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>1.0</td></tr><tr><td>list_key</td><td>列表型结果列表键</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>calc_rule</td><td>计算规则，公式</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>common_calc_rule</td><td>通用计算规则，最后生效</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>round_rule</td><td>修约规则</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>group_name</td><td>组名</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>create_user</td><td>nan</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>create_time</td><td>nan</td><td>datetime</td><td>DateTime</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>nan</td></tr><tr><td>change_user</td><td>nan</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>change_time</td><td>nan</td><td>datetime</td><td>DateTime</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>nan</td></tr><tr><td>deleted</td><td>nan</td><td>varchar</td><td>string</td><td>nan</td><td>nan</td><td>是</td><td>200.0</td><td>nan</td><td>nan</td></tr><tr><td>data_id</td><td>nan</td><td>int</td><td>int</td><td>nan</td><td>nan</td><td>是</td><td>nan</td><td>nan</td><td>nan</td></tr></tbody></table>',2),i=[e];function h(s,c){return t(),d("div",null,i)}const m=a(r,[["render",h],["__file","analysis_item.html.vue"]]);export{m as default};