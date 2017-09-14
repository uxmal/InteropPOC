#pragma once
class MyPlugin : public IRekoPlugin
{
public:
	MyPlugin(IRekoProgram * program);
	virtual ~MyPlugin();
private:
	IRekoProgram * program;
};

