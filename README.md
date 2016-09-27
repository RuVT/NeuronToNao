#Este proyecto pretende leer los datos mandados por el traje Neuron y replicar los movimientos en el robot NAO.

##Estructura del repositorio

```
C:.
+---C++					
¦   +---NeuronDataReader SDK b15			//SDK de Neuron
¦   ¦   +---NeuronDataReader Runtime API Documentation_D16.pdf  
¦   ¦   +---Windows							//Version para Windows
¦   ¦       +---include						//Clases y cabeceras a incluir
¦   ¦       ¦	+---DataType.h
¦   ¦       ¦    +---NeuronDataReader.h			
¦   ¦       +---lib
¦   ¦           +---x86						//Libreria para 32 bits
¦   ¦               +---NeuronDataReader.dll
¦   ¦               +---NeuronDataReader.lib
¦   +---neuronTest			
¦       +---neuronTest.sln					//Solucion de visual studio de c++
¦       +---TestConsole			
¦           +---TestConsole.vcxproj			//Proyecto ejemplo
¦           +---main.cpp					//Codigo principal
¦           +---main.h						//Cabecera principal
+---Python									//Ejemplos en python
    +---motion_taskManagement2.py
    +---TestNaoMotion.py
```

##Intrucciones:

1.- Abrir AxisNeuron y dentro de File>Settingd>Broadcasting seleccionar TCP, 127.0.0.1 como direccion host, y activar BVH en el puerto 7001.

![alt tag](https://github.com/RuVT/NeuronToNao/blob/master/Image/Settings.PNG?raw=true)

2.- Abrir neuronTest.sln, si el puerto o direccion es diferente modificarla dentro de main.cpp.

![alt tag](https://github.com/RuVT/NeuronToNao/blob/master/Image/main.cpp.PNG?raw=true)

3.- Compilar el proyecto, seleccionar alguno de los ejemplos pregrabados en AxisNeuron y comprobar que se reciban las coordenadas.

![alt tag](https://github.com/RuVT/NeuronToNao/blob/master/Image/AxisNeuron.PNG?raw=true)


![alt tag](https://github.com/RuVT/NeuronToNao/blob/master/Image/TestConsole.PNG?raw=true)
