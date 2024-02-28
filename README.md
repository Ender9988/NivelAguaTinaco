# NivelAguaTinaco
Sistema de Control de Nivel de Agua para Tinaco

Interfaz Gráfica de Usuario: 
La interfaz gráfica de usuario está desarrollada en Visual Basic. Esta interfaz proporciona una manera intuitiva para que el usuario interactúe con el sistema. Puede mostrar información en tiempo real sobre el nivel de agua en el tinaco y las acciones automáticas que el sistema debe realizar en función de ese nivel.

Hardware: 
El sistema hace uso de un microcontrolador Bluepill, que es una placa de desarrollo basada en el microcontrolador STM32 de STMicroelectronics. Este microcontrolador se encarga de leer los datos del sensor de nivel de agua en el tinaco y, posiblemente, controlar las válvulas o bombas de agua según sea necesario para mantener un nivel deseado en el tinaco.

Comunicación: 
La comunicación entre el microcontrolador Bluepill y la aplicación en Visual Basic se realiza a través de caracteres que son enviados y recibidos a través de un puerto serial. El microcontrolador envía los datos de lectura del sensor de nivel de agua al software en Visual Basic, y este a su vez puede enviar comandos de control al microcontrolador para ajustar el flujo de agua según sea necesario.
