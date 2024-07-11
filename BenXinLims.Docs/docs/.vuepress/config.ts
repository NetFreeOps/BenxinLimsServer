import { defaultTheme, defineUserConfig } from 'vuepress'
import { viteBundler } from '@vuepress/bundler-vite'



export default defineUserConfig({
  lang: 'zh-CN',
  title: '本心LIMS',
  description: '一个小型LIMS',
  base:'/BenxinLimsServer/',
  bundler: viteBundler({
    viteOptions: {
      build: {
        rollupOptions: {
          external: ['vue', 'vue/server-renderer']  
        }
      }
    },
    vuePluginOptions: {},
  }),
  theme: defaultTheme({
    sidebarDepth: 3,
    logo: '/images/logo.png',
    home: '/',
    repo: 'https://github.com/NetFreeOps/BenxinLimsServer',
    navbar: [{ text: "首页", link: "/" }, { text: "文档", link: "/function-system/sampleFunction" }],
    sidebar: [
      {
        text: "系统引导",
        link: '/guide/introduction',
        children: [
          { text: "系统介绍", link: "/guide/introduction" },
          { text: "快速开始", link: "/guide/quickStart" },
          { text: "数据库配置", link: "/guide/dbConfig" },
          { text: "缓存配置", link: "/guide/cacheConfig" },]
      },
      {
        text: "功能梳理",
        link:'/function-sorting/login-function',
        children:[
          {text:"登录流程",link:"/function-sorting/login-function"},
          {text:"任务管理",link:"/task-manager/taskAssignment"},
          {text:"工作流管理",link:"/work-flow/guide"}
        ]
      },
      {
        text: "内置函数",
        link: '/function-system/sampleFunction',
        children: [
          { text: "样品函数", link: "/function-system/sampleFunction" },
          { text: "检测函数", link: "/function-system/testFunction" },
          { text: "结果函数", link: "/function-system/resultFunction" },
          { text: "分析方法函数", link: "/function-system/analysisFunction" },
          { text: "设备函数", link: "/function-system/instrumentFunction" },
          { text: "人员函数", link: "/function-system/userFunction" }]

      },{
        text:'日志系统',
        link:'/log-system/description',
        children:[
          {text:'日志介绍',link:'/log-system/description'},
          {text:'日志记录',link:'/log-system/logRecord'}
        ]
      },{
        text:'数据库文档',
        link:'/database/tables',
        children:[
          { text: 'Sys user config', link: '/database/sys_user_config' },
          { text: 'Sys user', link: '/database/sys_user' },
          { text: 'Sys login log', link: '/database/sys_login_log' },
          { text: 'Sys role button', link: '/database/sys_role_button' },
          { text: 'Sys role data', link: '/database/sys_role_data' },
          { text: 'Sys role menu', link: '/database/sys_role_menu' },
          { text: 'Sys roles', link: '/database/sys_roles' },
          { text: 'Sys user role', link: '/database/sys_user_role' },
          { text: 'Sys user workflow', link: '/database/sys_user_workflow' },
          { text: 'Analysis', link: '/database/analysis' },
          { text: 'Lims list', link: '/database/lims_list' },
          { text: 'Lims list item', link: '/database/lims_list_item' },
          { text: 'Analysis calc', link: '/database/analysis_calc' },
          { text: 'Analysis item', link: '/database/analysis_item' },
          { text: 'Common calc', link: '/database/common_calc' },
          { text: 'Process unit', link: '/database/process_unit' },
          { text: 'Product', link: '/database/product' },
          { text: 'Test list', link: '/database/test_list' },
          { text: 'Test list item', link: '/database/test_list_item' },
          { text: 'User post', link: '/database/user_post' }
          
        ]
      }
    ]
  })
})
