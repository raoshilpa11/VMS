--select * from vehicle_records

--select * from VEHICLE_RECORDS_PROPERTIES

--delete from vehicle_records where VR_ID=6

SELECT R.VR_ID, VRP.VPM_ID VPM, VRP.VALUE
                    FROM VEHICLE_RECORDS R FULL OUTER JOIN VEHICLE_RECORDS_PROPERTIES VRP
                    ON R.VR_ID = VRP.VR_ID
                    LEFT JOIN VEHICLE_MAKEMODEL_MAPPING VMM
                    ON R.VMMP_ID = VMM.VMMP_ID
                    LEFT JOIN VEHICLETYPE T
				    ON VMM.VT_ID = T.VT_ID                    
                    WHERE R.VR_ID = 7