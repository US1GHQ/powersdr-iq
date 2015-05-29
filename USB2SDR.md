# USB2SDR #

Please see the updated USB2SDR informations Home here
-> http://www.wb5rvz.com/usb2sdr/index.htm

Also the support Yahoo! group here
-> http://groups.yahoo.com/group/powersdr-iq/



One of the real benefits of SDR is using very low IF due to its QSD/QSE design, in the range of 100 or 200 KHz.

That lead us to utilize readily available ADC and DAC from the audio/sound technology and we ended up using the PCs audio sound cards as the IF means apart from the standard microphone and speaker.

Although it can be used, this PC sound card solution has lots of other problems and we were giving more effort to the sound card setup rather to the SDR rig.

Also the ADC component is of paramount importance actually 'being' the major part of our receiver and exhibiting large performance differences from a vendor to another.

So these issues had to be resolved and a proper performing solution with ease on setup and without hassle was needed to the home brew SDR community.

So, here comes the USBtoSDR.

The USBtoSDR is a solution that plugs into a USB 2.0 highspeed port and acts pretty much like the Ozy/Janus combo from HPSDR but it is suited to the home brew SDR designs with QSD for reception and QSE for transmission.

The solution gives one USB 2.0 port as a unique connection to the PC, a separate RJ45 handheld mic connector with PTT, a separate phones connection, a CW straight/paddles connection, two high performance ADC ports for rig's Rx I/Q, two high performance DAC ports for rig's Tx I/Q and external interface with I2C bus and 8 general purpose I/O lines.

In its basic configuration, USBtoSDR has 4 mono inputs and 4 mono outputs (4+4), with 192KHz sampling rate at 32bits.

The ADC is having a dynamic range of 92 db and the DAC of 100 db.

These numbers are in the range of the Flex1500 whereas the sampling rate is 4 times higher effectively showing 4 times larger panadapter view.

As an upgrade, there is an option board, giving additional 2 mono inputs (ADC) and 2 mono outputs (DAC).

It contains the best performer in 24 bit ADC with 123dB dynamic range, the AK5394A (used in F5K and Janus).

Also there is a firmware version that enables USBtoSDR to adhere to the HPSDR USB protocol thus can be attached to the PowerSDR and be enabled from the Ozy/Janus selection setup.

And of course it is directly supported in PowerSDR-IQ application.

Enjoy !



If you would like to participate in a USB2SDR group buy please
send an email to

sv1eia @ gmail dot com


---





---
