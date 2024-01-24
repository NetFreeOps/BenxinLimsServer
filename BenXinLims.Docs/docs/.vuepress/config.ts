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
    logo: '/logo.png',
    home: '/',
    repo: 'https://github.com/NetFreeOps/BenxinLimsServer',
    navbar: [{ text: "首页", link: "/" }, { text: "文档", link: "/function-system/sampleFunction" }],
    sidebar: [
      {
        text: "系统引导",
        link: '/guide/',
        children: [
          { text: "系统介绍", link: "/guide/introduction" },
          { text: "快速开始", link: "/guide/quickStart" },
          { text: "数据库配置", link: "/guide/dbConfig" },
          { text: "缓存配置", link: "/guide/cacheConfig" },]
      },
      {
        text: "内置函数",
        link: '/function-system/',
        children: [
          { text: "样品函数", link: "/function-system/sampleFunction" },
          { text: "检测函数", link: "/function-system/testFunction" },
          { text: "结果函数", link: "/function-system/resultFunction" },
          { text: "分析方法函数", link: "/function-system/analysisFunction" },
          { text: "设备函数", link: "/function-system/instrumentFunction" },
          { text: "人员函数", link: "/function-system/userFunction" }]

      }
    ]
  })
})
