import{openBlock as i,createElementBlock as e,createStaticVNode as l}from"vue";import{_ as a}from"./app-Y3nPrZJQ.js";const r={},h=l('<h2 id="登录功能" tabindex="-1"><a class="header-anchor" href="#登录功能" aria-hidden="true">#</a> 登录功能</h2><h3 id="功能描述" tabindex="-1"><a class="header-anchor" href="#功能描述" aria-hidden="true">#</a> 功能描述</h3><ol><li>输入账号和密码，验证账号的可用性。</li><li>选择用户具有的角色，如果只有一个角色，则默认直接选中。</li><li>系统返回当前用户的配置信息，包括当前角色的菜单权限、按钮权限以及用户常用的功能排序。</li></ol><h3 id="输入" tabindex="-1"><a class="header-anchor" href="#输入" aria-hidden="true">#</a> 输入</h3><ul><li>账号：用户输入的账号信息。</li><li>密码：用户输入的密码信息。</li></ul><h3 id="输出" tabindex="-1"><a class="header-anchor" href="#输出" aria-hidden="true">#</a> 输出</h3><ul><li>验证结果：账号的可用性验证结果。</li><li>角色列表：用户具有的角色列表。</li><li>当前角色：当前选中的角色。</li><li>菜单权限：当前角色的菜单权限。</li><li>按钮权限：当前角色的按钮权限。</li><li>常用功能排序：用户常用的功能排序。</li></ul><h3 id="流程" tabindex="-1"><a class="header-anchor" href="#流程" aria-hidden="true">#</a> 流程</h3><ol><li>用户输入账号和密码。</li><li>系统验证账号的可用性。</li><li>如果账号可用，系统获取用户具有的角色列表。</li><li>如果只有一个角色，系统默认选中该角色。</li><li>系统返回当前用户的配置信息，包括菜单权限、按钮权限和常用功能排序。</li></ol><h3 id="示例代码" tabindex="-1"><a class="header-anchor" href="#示例代码" aria-hidden="true">#</a> 示例代码</h3>',10),d=[h];function n(t,o){return i(),e("div",null,d)}const u=a(r,[["render",n],["__file","login-function.html.vue"]]);export{u as default};
