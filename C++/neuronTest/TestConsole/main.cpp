#include <iostream>
#include "NeuronDataReader.h"
#include <Windows.h>
#include "main.h"
using namespace std;

ReaderTest::ReaderTest(){
}

//Callback que sera activada en cada lectura del Neuron
void ReaderTest::bvhFrameDataReceived(void* customedObj, SOCKET_REF sender, BvhDataHeader* header, float* data)
{
	//Numero del sensor, 0 es el sensor ubicado en la cadera
	int CurSel = 0;
	//Calcular el indice
	int dataIndex = CurSel * 6;
	if(header->WithReference)
	{
		dataIndex += 6;
	}
	//Optener las coordenadas
	float dispX = data[dataIndex + 0];
	float dispY = data[dataIndex + 1];
	float dispZ = data[dataIndex + 2];
	char strBuff[32];
	//Convertir float en strings e imprimir en pantalla
	sprintf_s(strBuff, sizeof(strBuff), "%0.3f", dispX);
	cout << "X = " << strBuff;
	sprintf_s(strBuff, sizeof(strBuff), "%0.3f", dispY);
	cout << ", Y = " << strBuff;
	sprintf_s(strBuff, sizeof(strBuff), "%0.3f", dispZ);
	cout << ", Z = " << strBuff << endl;
}

//Este metodo registra el callback par sea activado
void ReaderTest::SetCallback()
{
	BRRegisterFrameDataCallback(this, bvhFrameDataReceived);
}

int main()
{
	SOCKET_REF mySocket;
	//Crear objeto de la clase
	ReaderTest myReader = ReaderTest();
	//Registrar el callback
	myReader.SetCallback();
	//Abrir la conexion (IP, PUERTO)
	mySocket = BRConnectTo("127.0.0.1", 7001);
	while(true)
	{
		//Comprobar el estado de la conexion
		SocketStatus status = BRGetSocketStatus(mySocket);
		if(mySocket)
		{
			switch (status)
			{
			case CS_Running:
					cout << "Conectado\n";		
				break;
			case CS_Starting:
					cout << "Iniciando...\n";
				break;
			case CS_OffWork:
					cout << "OffLine\n";
				break;
			}
		}
		else
		{
			cout << "Desconectado\n";
		}
		//Detener durante unos 500 milisegundos
		Sleep(500);
	}
	//Cerrar la conexion
	BRCloseSocket(mySocket);
	//Esperar a input de usuario
	cin.get();
	//Regresar 0, operacion exitosa
	return 0;
}