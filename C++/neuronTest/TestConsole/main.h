
#include "DataType.h"
#include "NeuronDataReader.h"

class ReaderTest
{
public:
	ReaderTest();
	SOCKET_REF sockTCPRef;
	SOCKET_REF sockUDPRef;
	static void __stdcall bvhFrameDataReceived(void* customedObj, SOCKET_REF sender, BvhDataHeader* header, float* data);
	void SetCallback();

};