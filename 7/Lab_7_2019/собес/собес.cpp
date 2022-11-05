#include <iostream>

using namespace std;

struct ABase
{
	ABase()
	{
		cout << "ABase" << endl;
	}

	~ABase()
	{
		cout << "~ABase" << endl;
	}
};

struct BBase
{
	BBase()
	{
		cout << "BBase" << endl;
	}

	~BBase()
	{
		cout << "~BBase" << endl;
	}
};

struct AField
{
	AField()
	{
		cout << "AField" << endl;
	}

	~AField()
	{
		cout << "~AField" << endl;
	}
};

struct BField
{
	BField()
	{
		cout << "AField" << endl;
	}

	~BField()
	{
		cout << "~AField" << endl;
	}
};


struct Current : ABase, BBase
{
	Current()
	{
		cout << "Current" << endl;
	}

	~Current()
	{
		cout << "~Current" << endl;
	}

	BField b;
	AField A;
};

int main()
{
	Current current;
}