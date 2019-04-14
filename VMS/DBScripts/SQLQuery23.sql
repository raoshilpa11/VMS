SELECT R.VR_ID VRId, T.VT_ID VtId, MMM.VMMP_ID VMMPId, T.VEHICLETYPE_NAME Type,
                            MAKE.VEHICLEMAKE_NAME Make,
                            MAKE.VMAKE_ID VmakeId, MODELS.VEHICLEMODEL_NAME Model, MODELS.VMODEL_ID VmodelId
                            FROM VEHICLE_RECORDS R
				            LEFT JOIN VEHICLE_MAKEMODEL_MAPPING MMM
				            ON R.VMMP_ID = MMM.VMMP_ID
				            LEFT JOIN VEHICLETYPE T
				            ON MMM.VT_ID = T.VT_ID
				            LEFT OUTER JOIN VEHICLE_MAKE MAKE
                            ON MMM.VMAKE_ID = MAKE.VMAKE_ID 
                            LEFT OUTER JOIN VEHICLE_MODEL MODELS
                            ON MMM.VMODEL_ID = MODELS.VMODEL_ID
                            WHERE                 
                            --AND R.VR_ID = 1
                            MMM.VT_ID = 1

select * from vehicle_records