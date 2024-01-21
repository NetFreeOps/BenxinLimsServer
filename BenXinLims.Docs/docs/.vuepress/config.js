// .vuepress/config.js

module.exports = {
    title: '本心LIMS',
    description: '本心LIMS-小型LIMS',
  
    themeConfig: {
      logo: 'https://vuejs.org/images/logo.png',
  
      navbar: [
        { text: '首页', link: '/' },
        { text: '指南', link: '/guide/' },
        { text: '配置', link: '/config/' },
      ],
  
      sidebar: [
        {
          text: '指南',
          children: ['/guide/README.md', '/guide/using-vue.md'],
        },
        {
          text: '配置',
          children: ['/config/README.md', '/config/page.md'],
        },
      ],
    },
  }