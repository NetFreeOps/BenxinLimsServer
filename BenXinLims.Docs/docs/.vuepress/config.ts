import { defaultTheme, defineUserConfig } from 'vuepress'
import { viteBundler } from '@vuepress/bundler-vite'
import { webpackBundler } from '@vuepress/bundler-webpack'



export default defineUserConfig({
  lang: 'zh-CN',
  title: '本心LIMS',
  description: '一个小型LIMS',
  base:'/BenxinLimsServer/tree/main/BenXinLims.Docs/',
  // specify bundler via environment variable
  bundler:
    process.env.DOCS_BUNDLER === 'webpack' ? webpackBundler() : viteBundler(),
    
  theme: defaultTheme({
    sidebarDepth: 3,
    logo: '/logo.png',
    home: '/',
    repo: 'https://github.com/NetFreeOps/BenxinLimsServer',
    navbar: [{ text: "首页", link: "/" }, { text: "文档", link: "/function-system/sampleFunction.md" }],
    sidebar: [
      {
        text: "系统引导",
        link: '/guide/',
        children: [
          { text: "系统介绍", link: "/guide/introduction.md" },
          { text: "快速开始", link: "/guide/quickStart.md" },
          { text: "数据库配置", link: "/guide/dbConfig.md" },
          { text: "缓存配置", link: "/guide/cacheConfig.md" },]
      },
      {
        text: "内置函数",
        link: '/function-system/',
        children: [
          { text: "样品函数", link: "/function-system/sampleFunction.md" },
          { text: "检测函数", link: "/function-system/testFunction.md" },
          { text: "结果函数", link: "/function-system/resultFunction.md" },
          { text: "分析方法函数", link: "/function-system/analysisFunction.md" },
          { text: "设备函数", link: "/function-system/instrumentFunction.md" },
          { text: "人员函数", link: "/function-system/userFunction.md" }]

      }
    ]
  })
})
