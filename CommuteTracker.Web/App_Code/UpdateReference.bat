cd app_code
REM svcutil /t:metadata http://glacier:9000/CommuteTrackerService/Service.svc
 svcutil /t:metadata net.tcp://localhost:901/mex
svcutil *.wsdl *.xsd /l:c#
del *.xsd
del *.config
del *.wsdl