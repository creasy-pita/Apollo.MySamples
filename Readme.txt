2018-8-14
	����
		�ȸ������� �����ϴ��� OnChange ��û�б�����
	���
		֮ǰֱ���ֶ��޸� ͬ�����ͻ��˵����ã����ֲ����ᴥ��onchange
		����ڷ����apollo���������޸� ������������onchange�¼�


2018-8-13

appllo netcore �ͻ���quickstart

1 QuickStart4_WebApiClienWithApollo.Configuration

ʹ�� Microsoft.Extensions.Configuration���� ʹ��Com.Ctrip.Framework.Apollo.Configuration  ��ʹ��addjsonfile ("appsettings.json").
��System.Configuration.ConfigurationManager����(.net 4.7.1���Ժ�汾)ʹ��[Com.Ctrip.Framework.Apollo.ConfigurationManager] ��ʹ�� app.config�ļ�

appconfig.json ��Ҫ�޸�  copy to outputdirectory ����Ϊ copy



	�ͻ��˻ᱣ�����ø����������apollo���ĵĶ�Ӧ���ݸ��� �ͻ��˻�ȥ��ȡ apollo���ĵ���������ȸ���

	�ȸ���
		�������
		
		Ӧ�ÿͻ�����apollo����˵��ȸ���
			ͨ���ͻ���������ȡʵ��
			Ĭ��30���� ��ȡ1��
			������չ ʵ��ʵʱ���£���Ҫ������չ�� ����鿴 https://github.com/ctripcorp/apollo/wiki/%E5%85%B6%E5%AE%83%E8%AF%AD%E8%A8%80%E5%AE%A2%E6%88%B7%E7%AB%AF%E6%8E%A5%E5%85%A5%E6%8C%87%E5%8D%97 1.4��
		Ӧ���ڲ� ʹ�����õ� ����������ȸ���
			ʹ��һ�´��� ע�� �����ļ��ĸ��£�  

            var services = new ServiceCollection();
            services.AddOptions()
				.Configure<ApplicationSetting>(config);

			var optionsMonitor = serviceProvider.GetService<IOptionsMonitor<ApplicationSetting>>();
            optionsMonitor.OnChange(OnChanged);
	����
		�ȸ������� �����ϴ��� OnChange ��û�б����ã������� TBD	
			ApolloConfigManager build�� configuration����work
			
		����
			��ApolloConfigManager�д����� Configuration �����ϲ���startup�е� Configuration��Ӧ�ÿ��� work
			