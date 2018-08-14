2018-8-14
	问题
		热更新问题 ，以上代码 OnChange 并没有被调用
	解决
		之前直接手动修改 同步到客户端的配置，发现并不会触发onchange
		如果在服务端apollo配置中心修改 可以正常触发onchange事件


2018-8-13

appllo netcore 客户端quickstart

1 QuickStart4_WebApiClienWithApollo.Configuration

使用 Microsoft.Extensions.Configuration集成 使用Com.Ctrip.Framework.Apollo.Configuration  会使用addjsonfile ("appsettings.json").
与System.Configuration.ConfigurationManager集成(.net 4.7.1及以后版本)使用[Com.Ctrip.Framework.Apollo.ConfigurationManager] 会使用 app.config文件

appconfig.json 需要修改  copy to outputdirectory 属性为 copy



	客户端会保存配置副本，如果的apollo中心的对应内容更新 客户端会去获取 apollo中心的内容完成热更新

	热更新
		两层概念
		
		应用客户端与apollo服务端的热更新
			通过客户端主动拉取实现
			默认30秒钟 拉取1次
			可以扩展 实现实时更新，需要定义扩展类 具体查看 https://github.com/ctripcorp/apollo/wiki/%E5%85%B6%E5%AE%83%E8%AF%AD%E8%A8%80%E5%AE%A2%E6%88%B7%E7%AB%AF%E6%8E%A5%E5%85%A5%E6%8C%87%E5%8D%97 1.4节
		应用内部 使用配置的 各个组件的热更新
			使用一下代码 注册 配置文件的更新，  

            var services = new ServiceCollection();
            services.AddOptions()
				.Configure<ApplicationSetting>(config);

			var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<ApplicationSetting>>();
            optionsMonitor.OnChange(OnChanged);
	问题
		热更新问题 ，以上代码 OnChange 并没有被调用？？？？ TBD	
			ApolloConfigManager build的 configuration不能work
			
		尝试
			把ApolloConfigManager中创建的 Configuration 代码块合并到startup中的 Configuration，应该可以 work
			