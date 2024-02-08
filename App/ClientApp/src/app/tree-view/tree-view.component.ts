import { Component, Input } from '@angular/core';
import { TreeCategory } from '../shared/models/treeCategory';
import {Expandable} from "../shared/models/expandable";

@Component({
  selector: 'app-tree-view',
  templateUrl: './tree-view.component.html',
  styleUrls: ['./tree-view.component.css']
})
export class TreeViewComponent {
  // @ts-ignore
  // @ts-ignore
  @Input() treeCategories: TreeCategory[] = [
    {
      "categoryId": "CATB8C447C7",
      "concurrencyStamp": "CS6D9C1D2F",
      "createdAt": new Date('2023-04-05T16:43:57.561023'),
      "description": "Category description DDBDCE391",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT05F2E15F",
          "concurrencyStamp": "CS5FE5D96F",
          "createdAt": new Date('2023-06-06T19:31:47.944952'),
          "description": "Activity description D9BFF1272",
          "endTime": new Date('2023-12-10T01:25:11.812599'),
          "modifiedAt": new Date('2024-01-27T20:46:33.253397'),
          "name": "Activity NDF7A3B48",
          "startTime": new Date('2023-12-21T09:03:55.464918'),
          "userId": "UEF4B7587"
        },
        {
          "activityId": "ACT592A9775",
          "concurrencyStamp": "CS63356A9D",
          "createdAt": new Date('2023-07-13T16:36:23.052466'),
          "description": "Activity description D87E3053A",
          "endTime": new Date('2023-08-12T14:32:47.152969'),
          "modifiedAt": new Date('2023-03-11T13:23:50.867043'),
          "name": "Activity N41C05D13",
          "startTime": new Date('2023-07-25T22:52:15.040364'),
          "userId": "U45720F49"
        },
        {
          "activityId": "ACTA947DEB3",
          "concurrencyStamp": "CS891AA460",
          "createdAt": new Date('2023-08-05T11:35:12.190201'),
          "description": "Activity description D9E8199AA",
          "endTime": new Date('2023-02-02T03:23:35.701976'),
          "modifiedAt": new Date('2023-11-29T01:29:21.669910'),
          "name": "Activity NC3ADC14B",
          "startTime": new Date('2023-06-29T09:16:34.447790'),
          "userId": "UDDCC1386"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT8876A827",
              "concurrencyStamp": "CS738BA104",
              "createdAt": new Date('2023-03-13T23:05:13.792421'),
              "description": "Activity description D17E07AD5",
              "endTime": new Date('2023-07-29T16:20:06.419922'),
              "modifiedAt": new Date('2023-02-13T11:59:14.962554'),
              "name": "Activity N7B51A808",
              "startTime": new Date('2023-04-28T09:59:13.573994'),
              "userId": "UC3438832"
            },
            {
              "activityId": "ACT4A14EE08",
              "concurrencyStamp": "CS13C2E372",
              "createdAt": new Date('2023-07-12T06:16:59.000531'),
              "description": "Activity description DA6F24BB1",
              "endTime": new Date('2023-10-02T19:19:09.650238'),
              "modifiedAt": new Date('2023-07-27T23:45:17.106652'),
              "name": "Activity N47A7AF6F",
              "startTime": new Date('2023-06-25T05:34:46.632806'),
              "userId": "U3BB57D94"
            },
            {
              "activityId": "ACT8B6F61EB",
              "concurrencyStamp": "CS2B89E748",
              "createdAt": new Date('2023-08-24T12:35:17.812069'),
              "description": "Activity description D4100CD52",
              "endTime": new Date('2023-09-24T04:31:25.697126'),
              "modifiedAt": new Date('2023-12-13T12:28:21.513046'),
              "name": "Activity N7D6F5AF1",
              "startTime": new Date('2023-09-15T22:32:24.848236'),
              "userId": "U84B74F82"
            }
          ],
          "concurrencyStamp": "CS009BBE5E",
          "createdAt": new Date('2023-03-09T15:18:31.294341'),
          "description": "Job description D34D24DAE",
          "isExpanded": false,
          "jobId": "JOB87D27540",
          "modifiedAt": new Date('2023-12-23T12:25:02.899716'),
          "name": "Job Name N778F3435",
          "userId": "U45CF2668"
        },
        {
          "activities": [
            {
              "activityId": "ACT2DEBDA1E",
              "concurrencyStamp": "CS0252DD1A",
              "createdAt": new Date('2023-11-07T23:40:58.351994'),
              "description": "Activity description D9C92061F",
              "endTime": new Date('2023-08-14T15:26:50.332391'),
              "modifiedAt": new Date('2023-06-03T03:37:24.500830'),
              "name": "Activity N789490F1",
              "startTime": new Date('2023-05-25T13:46:11.829893'),
              "userId": "U02DA21DE"
            },
            {
              "activityId": "ACTCF25F521",
              "concurrencyStamp": "CS92C39AC5",
              "createdAt": new Date('2023-05-19T04:31:31.650312'),
              "description": "Activity description D0C172153",
              "endTime": new Date('2023-03-10T08:09:33.674313'),
              "modifiedAt": new Date('2023-06-18T18:12:20.393677'),
              "name": "Activity N0DB932A1",
              "startTime": new Date('2023-01-29T00:51:42.167315'),
              "userId": "U6BAF2EF6"
            },
            {
              "activityId": "ACTCBE4D773",
              "concurrencyStamp": "CS5C642D14",
              "createdAt": new Date('2023-05-16T07:14:51.648614'),
              "description": "Activity description D40F0A0FF",
              "endTime": new Date('2023-12-08T09:34:01.316441'),
              "modifiedAt": new Date('2023-03-20T06:15:46.261520'),
              "name": "Activity ND5692285",
              "startTime": new Date('2024-01-19T04:06:20.033179'),
              "userId": "U9CC85F2E"
            },
            {
              "activityId": "ACTB8D1C1C4",
              "concurrencyStamp": "CS63477784",
              "createdAt": new Date('2023-08-22T07:58:12.355880'),
              "description": "Activity description DAF9DC106",
              "endTime": new Date('2023-05-03T10:32:43.677677'),
              "modifiedAt": new Date('2023-02-06T12:23:00.645589'),
              "name": "Activity N29377F80",
              "startTime": new Date('2023-09-28T13:38:34.519330'),
              "userId": "UBBB7BBE8"
            },
            {
              "activityId": "ACT58C0A4A5",
              "concurrencyStamp": "CS4D07487E",
              "createdAt": new Date('2023-11-23T11:43:39.657180'),
              "description": "Activity description DE94075B8",
              "endTime": new Date('2023-10-20T08:07:59.827572'),
              "modifiedAt": new Date('2023-10-08T19:04:48.127108'),
              "name": "Activity NFE646446",
              "startTime": new Date('2023-11-24T01:00:07.900616'),
              "userId": "UCADAA85A"
            }
          ],
          "concurrencyStamp": "CS61DB593E",
          "createdAt": new Date('2023-10-08T22:59:38.474149'),
          "description": "Job description DA940F98E",
          "isExpanded": false,
          "jobId": "JOB494E10FF",
          "modifiedAt": new Date('2023-07-20T13:27:35.886157'),
          "name": "Job Name NB599E061",
          "userId": "UD01F2865"
        },
        {
          "activities": [
            {
              "activityId": "ACTCF825AFF",
              "concurrencyStamp": "CSEC6D6682",
              "createdAt": new Date('2023-07-30T06:04:07.297640'),
              "description": "Activity description D20D383BF",
              "endTime": new Date('2023-05-15T10:15:30.920819'),
              "modifiedAt": new Date('2023-11-30T17:35:02.511736'),
              "name": "Activity NCC0A7364",
              "startTime": new Date('2023-11-15T16:07:18.135865'),
              "userId": "UB003C906"
            },
            {
              "activityId": "ACT601B1C9C",
              "concurrencyStamp": "CS08EE944E",
              "createdAt": new Date('2023-09-25T10:14:24.591230'),
              "description": "Activity description D2827FDDB",
              "endTime": new Date('2023-08-27T06:46:40.193488'),
              "modifiedAt": new Date('2023-06-02T19:11:17.716063'),
              "name": "Activity N9CBE75B3",
              "startTime": new Date('2023-04-07T10:11:57.491909'),
              "userId": "U9B5C29A8"
            }
          ],
          "concurrencyStamp": "CS5503E0F8",
          "createdAt": new Date('2023-04-06T01:23:25.075972'),
          "description": "Job description D8D1A6E75",
          "isExpanded": false,
          "jobId": "JOB92866177",
          "modifiedAt": new Date('2023-04-05T04:21:47.169882'),
          "name": "Job Name N3E5C3DAB",
          "userId": "U18F07C94"
        }
      ],
      "modifiedAt": new Date('2023-06-22T17:35:55.002130'),
      "name": "Category N50EEDDE1",
      "status": 0,
      "userId": "UA8651371"
    },
    {
      "categoryId": "CATBE8A155A",
      "concurrencyStamp": "CSEF5A867C",
      "createdAt": new Date('2023-06-14T01:56:27.277377'),
      "description": "Category description DFEA6822D",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT40855A72",
          "concurrencyStamp": "CS9845F132",
          "createdAt": new Date('2023-11-16T22:23:09.559933'),
          "description": "Activity description D8ED5D7A1",
          "endTime": new Date('2023-09-07T20:00:18.054881'),
          "modifiedAt": new Date('2023-12-20T04:43:04.287308'),
          "name": "Activity N48B83256",
          "startTime": new Date('2023-12-31T20:03:45.133469'),
          "userId": "U38A42F58"
        },
        {
          "activityId": "ACT18F3A88F",
          "concurrencyStamp": "CSE470C858",
          "createdAt": new Date('2023-07-27T18:38:28.864882'),
          "description": "Activity description D20FD6ED0",
          "endTime": new Date('2023-10-25T17:17:33.425068'),
          "modifiedAt": new Date('2023-04-12T21:04:46.564069'),
          "name": "Activity N11B129A1",
          "startTime": new Date('2024-01-26T08:49:14.613881'),
          "userId": "U1163D5D1"
        },
        {
          "activityId": "ACT2232F501",
          "concurrencyStamp": "CS5F5C024F",
          "createdAt": new Date('2023-02-18T04:45:56.781344'),
          "description": "Activity description DFF1B3B82",
          "endTime": new Date('2023-08-23T07:50:54.978355'),
          "modifiedAt": new Date('2023-10-25T17:29:53.724071'),
          "name": "Activity NF5DEF01A",
          "startTime": new Date('2023-11-02T09:50:24.204682'),
          "userId": "UFCBB0EAF"
        },
        {
          "activityId": "ACTFF73563C",
          "concurrencyStamp": "CS594EC010",
          "createdAt": new Date('2023-08-09T20:28:53.198751'),
          "description": "Activity description DC2A66C70",
          "endTime": new Date('2023-08-05T06:28:58.289454'),
          "modifiedAt": new Date('2023-07-10T04:40:22.411256'),
          "name": "Activity N708FC903",
          "startTime": new Date('2023-09-18T14:09:43.933459'),
          "userId": "U4AF2205D"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT9EC365F6",
              "concurrencyStamp": "CSFC74C42C",
              "createdAt": new Date('2023-04-28T05:19:09.345727'),
              "description": "Activity description D18050C49",
              "endTime": new Date('2023-06-03T16:38:48.963984'),
              "modifiedAt": new Date('2023-12-09T03:14:50.386176'),
              "name": "Activity NFCF4569F",
              "startTime": new Date('2023-09-26T13:35:17.344935'),
              "userId": "U5A781079"
            },
            {
              "activityId": "ACTEFCFCAE4",
              "concurrencyStamp": "CS4DE21B2D",
              "createdAt": new Date('2023-08-29T06:19:04.525312'),
              "description": "Activity description DF079CA6E",
              "endTime": new Date('2023-12-06T09:29:46.356567'),
              "modifiedAt": new Date('2023-08-03T10:25:33.709983'),
              "name": "Activity N59762AEC",
              "startTime": new Date('2023-02-19T14:22:47.530647'),
              "userId": "U06661A3D"
            }
          ],
          "concurrencyStamp": "CS1F57B8EA",
          "createdAt": new Date('2023-12-16T02:52:58.030320'),
          "description": "Job description DB3D2FCBA",
          "isExpanded": false,
          "jobId": "JOBF38FF251",
          "modifiedAt": new Date('2023-05-15T05:43:29.777251'),
          "name": "Job Name N3FC4F142",
          "userId": "UF281369A"
        },
        {
          "activities": [
            {
              "activityId": "ACTA5CE1A9A",
              "concurrencyStamp": "CS3128719F",
              "createdAt": new Date('2024-01-25T04:17:23.316856'),
              "description": "Activity description DE3FB7A2D",
              "endTime": new Date('2023-12-21T08:30:19.645803'),
              "modifiedAt": new Date('2023-07-17T04:21:06.802509'),
              "name": "Activity N3643B4EA",
              "startTime": new Date('2023-04-28T21:53:06.496348'),
              "userId": "UE672A32F"
            },
            {
              "activityId": "ACT68E98DA1",
              "concurrencyStamp": "CS3520A271",
              "createdAt": new Date('2023-10-30T08:46:46.551826'),
              "description": "Activity description DA94D1326",
              "endTime": new Date('2024-01-28T02:42:25.718656'),
              "modifiedAt": new Date('2023-06-25T23:17:04.087286'),
              "name": "Activity NF5B3EBD5",
              "startTime": new Date('2023-03-24T16:58:00.030165'),
              "userId": "U33AA585D"
            }
          ],
          "concurrencyStamp": "CS3AAAF8D3",
          "createdAt": new Date('2023-12-14T23:42:26.720339'),
          "description": "Job description DD39C5FBD",
          "isExpanded": false,
          "jobId": "JOBD1755810",
          "modifiedAt": new Date('2023-09-29T06:03:51.421524'),
          "name": "Job Name NAB4E6D6B",
          "userId": "U8AFFAD76"
        },
        {
          "activities": [
            {
              "activityId": "ACT3B7DEC65",
              "concurrencyStamp": "CS11E4F195",
              "createdAt": new Date('2024-01-19T20:08:27.466631'),
              "description": "Activity description D36DA610B",
              "endTime": new Date('2023-12-08T10:01:55.834674'),
              "modifiedAt": new Date('2023-06-26T01:08:31.637289'),
              "name": "Activity N81F9021C",
              "startTime": new Date('2023-07-23T16:16:19.089453'),
              "userId": "U9A77BC8B"
            },
            {
              "activityId": "ACT3285C6DA",
              "concurrencyStamp": "CS27DE286C",
              "createdAt": new Date('2023-04-01T12:06:04.391151'),
              "description": "Activity description D5D0C4A77",
              "endTime": new Date('2023-04-28T03:47:18.192537'),
              "modifiedAt": new Date('2024-01-14T12:31:55.146229'),
              "name": "Activity N0E2F70D8",
              "startTime": new Date('2023-09-04T02:37:02.298281'),
              "userId": "UBACAB2F9"
            },
            {
              "activityId": "ACTBE31128C",
              "concurrencyStamp": "CSFCD8ADE2",
              "createdAt": new Date('2023-02-06T14:12:02.316559'),
              "description": "Activity description D626BF20D",
              "endTime": new Date('2023-11-08T09:13:52.646613'),
              "modifiedAt": new Date('2023-02-04T11:57:51.103787'),
              "name": "Activity N05E677C3",
              "startTime": new Date('2023-03-17T21:40:19.049200'),
              "userId": "UB1DF1676"
            },
            {
              "activityId": "ACTC457A9D0",
              "concurrencyStamp": "CS9C0AA97F",
              "createdAt": new Date('2023-11-06T00:28:59.353068'),
              "description": "Activity description D4DDBC1FD",
              "endTime": new Date('2023-11-24T01:08:36.577615'),
              "modifiedAt": new Date('2023-03-28T09:36:24.691308'),
              "name": "Activity N64FC3CAD",
              "startTime": new Date('2024-01-20T14:09:08.045719'),
              "userId": "U943C576E"
            },
            {
              "activityId": "ACT6AE85D90",
              "concurrencyStamp": "CS8992F0AA",
              "createdAt": new Date('2023-04-28T18:52:26.769850'),
              "description": "Activity description D5186E12C",
              "endTime": new Date('2023-08-05T04:06:46.324550'),
              "modifiedAt": new Date('2023-09-25T18:45:39.350823'),
              "name": "Activity N4123EDFC",
              "startTime": new Date('2023-07-29T21:21:44.387110'),
              "userId": "U23A181E1"
            }
          ],
          "concurrencyStamp": "CSE3EE8194",
          "createdAt": new Date('2023-09-09T02:40:36.884351'),
          "description": "Job description D78BC790F",
          "isExpanded": false,
          "jobId": "JOB40A026AA",
          "modifiedAt": new Date('2023-10-02T16:12:43.315269'),
          "name": "Job Name N5527D95A",
          "userId": "U056640E8"
        },
        {
          "activities": [
            {
              "activityId": "ACT199773E4",
              "concurrencyStamp": "CS526C9C75",
              "createdAt": new Date('2023-08-11T16:46:26.481046'),
              "description": "Activity description D5F700C8F",
              "endTime": new Date('2023-10-27T07:37:28.719744'),
              "modifiedAt": new Date('2024-01-18T22:37:15.234205'),
              "name": "Activity NC6806F68",
              "startTime": new Date('2023-07-03T09:05:03.523914'),
              "userId": "UB1904B1B"
            },
            {
              "activityId": "ACT447228CA",
              "concurrencyStamp": "CS1C08A1C3",
              "createdAt": new Date('2024-01-23T14:08:22.999933'),
              "description": "Activity description DC02F2EAA",
              "endTime": new Date('2023-06-09T11:09:24.425044'),
              "modifiedAt": new Date('2023-10-06T19:59:05.861778'),
              "name": "Activity N7A4CBF7F",
              "startTime": new Date('2023-10-25T02:24:26.807910'),
              "userId": "UEAAF7C2E"
            },
            {
              "activityId": "ACT87BAE1CE",
              "concurrencyStamp": "CSA35C6A18",
              "createdAt": new Date('2023-04-23T09:17:02.281114'),
              "description": "Activity description DF40425CF",
              "endTime": new Date('2023-09-15T06:52:55.811989'),
              "modifiedAt": new Date('2023-07-23T03:43:21.976165'),
              "name": "Activity ND98E6059",
              "startTime": new Date('2023-07-18T09:19:39.938544'),
              "userId": "U41287C86"
            }
          ],
          "concurrencyStamp": "CS40DDA170",
          "createdAt": new Date('2023-02-05T07:26:22.861205'),
          "description": "Job description DCE98D69B",
          "isExpanded": false,
          "jobId": "JOB21BF91F4",
          "modifiedAt": new Date('2023-03-01T18:11:19.129793'),
          "name": "Job Name NACF878CB",
          "userId": "U87AB81D7"
        },
        {
          "activities": [
            {
              "activityId": "ACT22178524",
              "concurrencyStamp": "CS06FBC09C",
              "createdAt": new Date('2023-04-12T07:14:31.146003'),
              "description": "Activity description D330B6345",
              "endTime": new Date('2023-04-17T17:54:36.927169'),
              "modifiedAt": new Date('2023-06-17T11:20:47.197201'),
              "name": "Activity N7E2501C2",
              "startTime": new Date('2023-11-21T15:17:17.413888'),
              "userId": "U9A6DEB01"
            },
            {
              "activityId": "ACT28512996",
              "concurrencyStamp": "CS3A43DBBF",
              "createdAt": new Date('2023-03-26T06:07:19.925218'),
              "description": "Activity description D71348FD0",
              "endTime": new Date('2023-08-15T07:02:23.561382'),
              "modifiedAt": new Date('2023-03-10T16:18:29.631809'),
              "name": "Activity N5EF0100B",
              "startTime": new Date('2023-07-05T05:18:00.509054'),
              "userId": "UCA2651EC"
            },
            {
              "activityId": "ACTE420AB35",
              "concurrencyStamp": "CS80CB972C",
              "createdAt": new Date('2023-08-16T12:36:22.085542'),
              "description": "Activity description DFD1E2DEC",
              "endTime": new Date('2023-09-11T01:55:52.278923'),
              "modifiedAt": new Date('2023-03-27T13:32:30.743507'),
              "name": "Activity NEE7F722F",
              "startTime": new Date('2023-02-12T19:00:24.457784'),
              "userId": "U4C70BA79"
            },
            {
              "activityId": "ACT28E41B4A",
              "concurrencyStamp": "CS0F61C62B",
              "createdAt": new Date('2023-04-30T16:25:20.651393'),
              "description": "Activity description D7AAAB8E4",
              "endTime": new Date('2023-11-03T01:11:20.535962'),
              "modifiedAt": new Date('2023-12-27T22:30:59.136328'),
              "name": "Activity N79E57410",
              "startTime": new Date('2023-02-05T15:44:24.722562'),
              "userId": "U883C8AF5"
            }
          ],
          "concurrencyStamp": "CSF450AB98",
          "createdAt": new Date('2023-06-09T17:26:13.254478'),
          "description": "Job description D645FE9C1",
          "isExpanded": false,
          "jobId": "JOB99B4EFBA",
          "modifiedAt": new Date('2023-11-01T06:31:40.548366'),
          "name": "Job Name N336548A2",
          "userId": "UB50A26CA"
        }
      ],
      "modifiedAt": new Date('2023-08-20T13:46:41.341510'),
      "name": "Category N492F9BA6",
      "status": 3,
      "userId": "UCBBA154D"
    },
    {
      "categoryId": "CAT4DBA393C",
      "concurrencyStamp": "CSCB044DED",
      "createdAt": new Date('2023-12-19T01:57:10.328050'),
      "description": "Category description D1DB2EFDC",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT2132BA0A",
          "concurrencyStamp": "CSA0BBB211",
          "createdAt": new Date('2023-03-21T22:35:08.591629'),
          "description": "Activity description DAB4BB6D9",
          "endTime": new Date('2023-06-07T18:22:08.261549'),
          "modifiedAt": new Date('2023-08-20T21:19:26.827453'),
          "name": "Activity N844B5142",
          "startTime": new Date('2023-10-24T15:51:02.549520'),
          "userId": "UA1F3D365"
        },
        {
          "activityId": "ACT4158EC8A",
          "concurrencyStamp": "CS0A8D8E11",
          "createdAt": new Date('2023-09-06T10:30:03.602976'),
          "description": "Activity description DB3F86004",
          "endTime": new Date('2023-03-05T11:08:05.899712'),
          "modifiedAt": new Date('2023-04-06T12:33:14.930244'),
          "name": "Activity N74D3FB65",
          "startTime": new Date('2023-05-04T17:40:38.436730'),
          "userId": "U1CBEFFFD"
        },
        {
          "activityId": "ACT47572976",
          "concurrencyStamp": "CS37454501",
          "createdAt": new Date('2023-12-01T10:56:53.104913'),
          "description": "Activity description D5AC3D483",
          "endTime": new Date('2023-12-16T02:58:50.990224'),
          "modifiedAt": new Date('2023-11-12T14:15:09.593385'),
          "name": "Activity N7778C1C4",
          "startTime": new Date('2023-02-14T13:33:44.798004'),
          "userId": "U53ADB6BE"
        },
        {
          "activityId": "ACTF84E56E5",
          "concurrencyStamp": "CSE5A9D319",
          "createdAt": new Date('2023-06-13T11:45:08.383558'),
          "description": "Activity description D1F3CB06C",
          "endTime": new Date('2023-04-12T19:05:15.956293'),
          "modifiedAt": new Date('2023-04-14T09:11:54.448113'),
          "name": "Activity NA502DC0B",
          "startTime": new Date('2023-10-30T00:03:15.632600'),
          "userId": "U15D9B662"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT43E4977D",
              "concurrencyStamp": "CS17C6EF24",
              "createdAt": new Date('2023-05-01T11:04:05.999862'),
              "description": "Activity description DCCF31688",
              "endTime": new Date('2023-11-14T18:59:18.966954'),
              "modifiedAt": new Date('2024-01-16T08:00:34.343743'),
              "name": "Activity N8E312054",
              "startTime": new Date('2023-06-07T19:29:19.506018'),
              "userId": "U27B7A0F0"
            },
            {
              "activityId": "ACTBD0ABD1B",
              "concurrencyStamp": "CSCAC28B70",
              "createdAt": new Date('2023-03-27T10:35:57.958471'),
              "description": "Activity description D67A918A7",
              "endTime": new Date('2023-08-30T01:50:23.559163'),
              "modifiedAt": new Date('2023-11-07T07:44:05.063583'),
              "name": "Activity N841853DB",
              "startTime": new Date('2023-10-01T19:32:28.142393'),
              "userId": "U9B2082F5"
            }
          ],
          "concurrencyStamp": "CSDCB99AC0",
          "createdAt": new Date('2023-11-17T06:41:15.230880'),
          "description": "Job description D769F27BD",
          "isExpanded": false,
          "jobId": "JOB78B0CF25",
          "modifiedAt": new Date('2023-05-04T21:22:52.474675'),
          "name": "Job Name NEDD303E0",
          "userId": "U7A36A2B5"
        },
        {
          "activities": [
            {
              "activityId": "ACT9C06AC91",
              "concurrencyStamp": "CSBC20788E",
              "createdAt": new Date('2023-05-16T04:45:37.388071'),
              "description": "Activity description DA5B23CFA",
              "endTime": new Date('2023-04-04T19:20:48.300144'),
              "modifiedAt": new Date('2023-10-30T21:56:47.243189'),
              "name": "Activity N25053AE5",
              "startTime": new Date('2023-12-25T04:28:38.376978'),
              "userId": "UAD719A1C"
            },
            {
              "activityId": "ACT1FE55C81",
              "concurrencyStamp": "CS8B124102",
              "createdAt": new Date('2023-05-03T19:10:28.066233'),
              "description": "Activity description D6DB89991",
              "endTime": new Date('2023-04-25T14:31:22.709147'),
              "modifiedAt": new Date('2024-01-12T02:42:56.816858'),
              "name": "Activity N26F818BD",
              "startTime": new Date('2023-01-31T18:05:24.513754'),
              "userId": "UA2D32220"
            }
          ],
          "concurrencyStamp": "CS093EF7E2",
          "createdAt": new Date('2024-01-09T04:36:45.452797'),
          "description": "Job description DF2633F22",
          "isExpanded": false,
          "jobId": "JOB11B43293",
          "modifiedAt": new Date('2023-06-12T20:49:13.472192'),
          "name": "Job Name NF408D0DA",
          "userId": "UCA943EA7"
        },
        {
          "activities": [
            {
              "activityId": "ACT65FBBD5F",
              "concurrencyStamp": "CSE459F213",
              "createdAt": new Date('2023-05-24T17:09:32.614771'),
              "description": "Activity description D3BE323F6",
              "endTime": new Date('2023-03-25T23:34:36.879406'),
              "modifiedAt": new Date('2023-04-30T16:41:14.713366'),
              "name": "Activity NEBE83431",
              "startTime": new Date('2023-04-21T01:44:58.884390'),
              "userId": "U0B31FA9B"
            },
            {
              "activityId": "ACTEE52163C",
              "concurrencyStamp": "CS7ECA78E8",
              "createdAt": new Date('2023-02-08T05:15:10.858134'),
              "description": "Activity description DCA4CFD5C",
              "endTime": new Date('2023-10-14T22:17:06.693803'),
              "modifiedAt": new Date('2023-08-03T23:31:18.688497'),
              "name": "Activity NBD3133EB",
              "startTime": new Date('2023-08-26T05:03:48.161570'),
              "userId": "UA3D5FA48"
            },
            {
              "activityId": "ACTB7F298F6",
              "concurrencyStamp": "CSEADE2A73",
              "createdAt": new Date('2023-11-16T21:56:53.923023'),
              "description": "Activity description D1102430F",
              "endTime": new Date('2023-05-25T11:47:05.562558'),
              "modifiedAt": new Date('2023-09-14T07:18:25.554064'),
              "name": "Activity N2B9BE542",
              "startTime": new Date('2023-09-18T00:35:12.345158'),
              "userId": "UFFCF0778"
            }
          ],
          "concurrencyStamp": "CSBC1C4C79",
          "createdAt": new Date('2024-01-10T05:34:39.319000'),
          "description": "Job description DFCDE2210",
          "isExpanded": false,
          "jobId": "JOB95299131",
          "modifiedAt": new Date('2023-06-25T15:37:23.166242'),
          "name": "Job Name NECA9D88D",
          "userId": "UBC4B8BC9"
        },
        {
          "activities": [
            {
              "activityId": "ACTA1B85E5F",
              "concurrencyStamp": "CSBF3F6BF6",
              "createdAt": new Date('2023-08-26T16:26:27.058457'),
              "description": "Activity description D144C9839",
              "endTime": new Date('2023-08-25T14:32:26.866191'),
              "modifiedAt": new Date('2023-09-21T05:56:25.124294'),
              "name": "Activity N04258588",
              "startTime": new Date('2023-09-08T01:29:01.005802'),
              "userId": "UF416C935"
            },
            {
              "activityId": "ACT8279F26F",
              "concurrencyStamp": "CS3DE03971",
              "createdAt": new Date('2023-03-14T19:46:55.373488'),
              "description": "Activity description D616C828D",
              "endTime": new Date('2023-06-18T16:00:27.585109'),
              "modifiedAt": new Date('2023-03-05T03:46:24.746400'),
              "name": "Activity NFF8980C2",
              "startTime": new Date('2023-03-19T22:20:48.665957'),
              "userId": "UB75E6213"
            },
            {
              "activityId": "ACTC0A8C470",
              "concurrencyStamp": "CS234B2FEC",
              "createdAt": new Date('2024-01-20T05:06:07.972150'),
              "description": "Activity description D95B0B4E0",
              "endTime": new Date('2023-08-07T02:55:37.426039'),
              "modifiedAt": new Date('2023-08-14T12:41:44.459236'),
              "name": "Activity NA735A285",
              "startTime": new Date('2023-04-25T06:27:19.130307'),
              "userId": "U5A0F035C"
            },
            {
              "activityId": "ACT79E34865",
              "concurrencyStamp": "CS9359F85D",
              "createdAt": new Date('2023-06-14T04:48:58.181624'),
              "description": "Activity description DAFFD8412",
              "endTime": new Date('2023-09-03T12:51:47.550290'),
              "modifiedAt": new Date('2023-07-30T06:40:28.535839'),
              "name": "Activity N48BB58A0",
              "startTime": new Date('2023-12-28T06:49:07.811897'),
              "userId": "U9C8AEF06"
            }
          ],
          "concurrencyStamp": "CS3990A11E",
          "createdAt": new Date('2024-01-10T21:40:38.699006'),
          "description": "Job description D3C71D47E",
          "isExpanded": false,
          "jobId": "JOB6CC33208",
          "modifiedAt": new Date('2023-02-15T12:25:28.769712'),
          "name": "Job Name NA9B5EBB2",
          "userId": "U30DDC042"
        },
        {
          "activities": [
            {
              "activityId": "ACT1E5D5068",
              "concurrencyStamp": "CS6A956953",
              "createdAt": new Date('2023-05-29T02:50:13.988576'),
              "description": "Activity description DCC637C38",
              "endTime": new Date('2023-09-13T20:03:12.919815'),
              "modifiedAt": new Date('2023-10-09T04:58:42.356620'),
              "name": "Activity N4AE0233D",
              "startTime": new Date('2023-11-03T11:40:48.918876'),
              "userId": "UA789FC97"
            },
            {
              "activityId": "ACT2C2D5254",
              "concurrencyStamp": "CSEE7EB99D",
              "createdAt": new Date('2023-10-08T02:42:17.799972'),
              "description": "Activity description D7EBCE92B",
              "endTime": new Date('2023-09-19T20:43:24.377974'),
              "modifiedAt": new Date('2024-01-16T22:42:11.442623'),
              "name": "Activity NC759687E",
              "startTime": new Date('2023-08-22T06:14:10.911563'),
              "userId": "UEB06B407"
            },
            {
              "activityId": "ACT76AEA5AB",
              "concurrencyStamp": "CS932C4A60",
              "createdAt": new Date('2023-09-12T03:59:29.138829'),
              "description": "Activity description DC3A74958",
              "endTime": new Date('2023-03-27T21:39:24.631910'),
              "modifiedAt": new Date('2023-06-15T06:30:11.231482'),
              "name": "Activity N47FEAF5E",
              "startTime": new Date('2023-10-02T13:59:09.707505'),
              "userId": "U4D9670FB"
            },
            {
              "activityId": "ACTA43FEB42",
              "concurrencyStamp": "CS538EEC22",
              "createdAt": new Date('2023-02-16T00:07:07.378517'),
              "description": "Activity description D2914CC91",
              "endTime": new Date('2023-05-24T07:19:08.398074'),
              "modifiedAt": new Date('2024-01-24T02:56:51.097055'),
              "name": "Activity N3A1D8909",
              "startTime": new Date('2023-08-07T08:43:58.066833'),
              "userId": "U8BE29934"
            }
          ],
          "concurrencyStamp": "CSE3CE037D",
          "createdAt": new Date('2024-01-02T12:46:35.625721'),
          "description": "Job description D3AD54FF1",
          "isExpanded": false,
          "jobId": "JOBF2F2CF05",
          "modifiedAt": new Date('2023-05-30T21:07:57.994626'),
          "name": "Job Name N018FC2A2",
          "userId": "U18BF9F56"
        }
      ],
      "modifiedAt": new Date('2023-07-05T08:17:33.659449'),
      "name": "Category NE5B10828",
      "status": 3,
      "userId": "UF07A8C4E"
    },
    {
      "categoryId": "CAT472A108D",
      "concurrencyStamp": "CSA06D58A3",
      "createdAt": new Date('2023-04-23T12:41:53.014805'),
      "description": "Category description D01135B0A",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACTBAEF074E",
          "concurrencyStamp": "CSD9EFC4F3",
          "createdAt": new Date('2023-12-16T01:38:48.803029'),
          "description": "Activity description D44859706",
          "endTime": new Date('2024-01-19T13:48:07.799819'),
          "modifiedAt": new Date('2023-11-15T15:38:01.697851'),
          "name": "Activity ND633A634",
          "startTime": new Date('2023-10-11T09:27:18.737493'),
          "userId": "U2817A918"
        },
        {
          "activityId": "ACT90F65C8A",
          "concurrencyStamp": "CS7F719570",
          "createdAt": new Date('2023-05-29T18:34:53.394480'),
          "description": "Activity description D1EA4C5DD",
          "endTime": new Date('2024-01-20T16:36:35.810723'),
          "modifiedAt": new Date('2023-07-12T08:18:22.168023'),
          "name": "Activity N37E2ECFB",
          "startTime": new Date('2023-01-28T13:25:26.790878'),
          "userId": "UD3AF34C9"
        },
        {
          "activityId": "ACT6B83A427",
          "concurrencyStamp": "CSB2E7BA40",
          "createdAt": new Date('2023-03-03T23:19:10.570700'),
          "description": "Activity description DDBF88262",
          "endTime": new Date('2023-10-05T09:43:38.212556'),
          "modifiedAt": new Date('2023-03-02T14:33:20.332591'),
          "name": "Activity ND57B1910",
          "startTime": new Date('2023-02-10T03:04:57.437856'),
          "userId": "UDB7D82A1"
        },
        {
          "activityId": "ACT9CBA2B1E",
          "concurrencyStamp": "CS11A575EC",
          "createdAt": new Date('2023-06-29T22:37:07.876484'),
          "description": "Activity description D7879F071",
          "endTime": new Date('2023-12-05T17:51:10.465981'),
          "modifiedAt": new Date('2023-03-09T11:03:10.867797'),
          "name": "Activity NB569D4D3",
          "startTime": new Date('2023-06-04T20:27:32.572270'),
          "userId": "U670B5812"
        },
        {
          "activityId": "ACTE585D116",
          "concurrencyStamp": "CS3CA44775",
          "createdAt": new Date('2023-11-23T19:40:04.831574'),
          "description": "Activity description D284E5FDE",
          "endTime": new Date('2023-10-31T22:25:23.373789'),
          "modifiedAt": new Date('2023-08-27T05:30:07.413282'),
          "name": "Activity N01265543",
          "startTime": new Date('2023-06-03T19:23:06.890350'),
          "userId": "U7281B6A2"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACTB645436C",
              "concurrencyStamp": "CSD3784328",
              "createdAt": new Date('2023-05-15T00:38:58.984449'),
              "description": "Activity description D819C9C5B",
              "endTime": new Date('2024-01-24T00:51:47.654445'),
              "modifiedAt": new Date('2023-07-14T21:44:19.047052'),
              "name": "Activity N4C57CD8F",
              "startTime": new Date('2023-03-06T03:26:29.769591'),
              "userId": "U8ADA1DF8"
            },
            {
              "activityId": "ACT7553EEF6",
              "concurrencyStamp": "CS0B915B4E",
              "createdAt": new Date('2023-02-16T02:46:00.502736'),
              "description": "Activity description D0E7AB052",
              "endTime": new Date('2023-04-11T10:09:29.446781'),
              "modifiedAt": new Date('2023-05-28T17:53:50.557401'),
              "name": "Activity N3DB7E079",
              "startTime": new Date('2023-08-19T11:56:12.199207'),
              "userId": "UEC645565"
            },
            {
              "activityId": "ACT65379463",
              "concurrencyStamp": "CS136726A7",
              "createdAt": new Date('2023-11-11T01:42:02.288422'),
              "description": "Activity description D0013D682",
              "endTime": new Date('2024-01-11T03:22:55.326719'),
              "modifiedAt": new Date('2023-03-06T23:39:41.014969'),
              "name": "Activity ND47B97E0",
              "startTime": new Date('2023-10-11T06:05:48.753197'),
              "userId": "U728A5074"
            },
            {
              "activityId": "ACTED781909",
              "concurrencyStamp": "CSD053822F",
              "createdAt": new Date('2024-01-07T19:20:21.788526'),
              "description": "Activity description DC56272DA",
              "endTime": new Date('2024-01-25T04:51:29.196750'),
              "modifiedAt": new Date('2023-12-17T14:02:15.631770'),
              "name": "Activity NE40390DD",
              "startTime": new Date('2023-08-08T07:34:41.303334'),
              "userId": "U660319B7"
            }
          ],
          "concurrencyStamp": "CSB492F9F5",
          "createdAt": new Date('2023-06-09T01:35:03.940054'),
          "description": "Job description D44909A15",
          "isExpanded": false,
          "jobId": "JOB03401FC2",
          "modifiedAt": new Date('2023-08-20T20:15:25.034533'),
          "name": "Job Name NDFAFE353",
          "userId": "U20E3C4E7"
        },
        {
          "activities": [
            {
              "activityId": "ACTAA8A1C88",
              "concurrencyStamp": "CS8B278A82",
              "createdAt": new Date('2023-11-11T07:40:48.954853'),
              "description": "Activity description DB1069AEB",
              "endTime": new Date('2023-10-11T11:22:48.573568'),
              "modifiedAt": new Date('2023-02-17T14:55:25.420473'),
              "name": "Activity N38746BA7",
              "startTime": new Date('2023-11-01T09:03:16.721223'),
              "userId": "U0762512C"
            },
            {
              "activityId": "ACTA928F9E2",
              "concurrencyStamp": "CS18123463",
              "createdAt": new Date('2023-09-16T17:30:25.707291'),
              "description": "Activity description DC64745CD",
              "endTime": new Date('2023-06-04T13:26:19.809179'),
              "modifiedAt": new Date('2023-05-16T05:11:47.879130'),
              "name": "Activity NC446869F",
              "startTime": new Date('2023-03-19T11:53:05.649267'),
              "userId": "UC122256B"
            },
            {
              "activityId": "ACTF2274888",
              "concurrencyStamp": "CS5E46A417",
              "createdAt": new Date('2023-12-25T02:34:37.303859'),
              "description": "Activity description D5C0A8A1C",
              "endTime": new Date('2023-03-27T13:36:32.382828'),
              "modifiedAt": new Date('2023-07-14T11:17:26.947212'),
              "name": "Activity N8D2B5DD0",
              "startTime": new Date('2023-07-08T17:00:24.825093'),
              "userId": "U9FBF00D1"
            },
            {
              "activityId": "ACT55E57CF2",
              "concurrencyStamp": "CS15C34B76",
              "createdAt": new Date('2023-05-31T16:56:32.709683'),
              "description": "Activity description DE9E1D4CF",
              "endTime": new Date('2023-03-09T09:30:18.228401'),
              "modifiedAt": new Date('2023-06-17T15:10:49.676151'),
              "name": "Activity N2B8C236D",
              "startTime": new Date('2023-02-21T20:02:56.255551'),
              "userId": "U1C5F678F"
            }
          ],
          "concurrencyStamp": "CS9914F733",
          "createdAt": new Date('2023-09-22T09:06:57.929635'),
          "description": "Job description D9BA0F76D",
          "isExpanded": false,
          "jobId": "JOB772C4BDD",
          "modifiedAt": new Date('2023-04-14T05:12:34.163855'),
          "name": "Job Name N1E579D6F",
          "userId": "U0CBB966B"
        },
        {
          "activities": [
            {
              "activityId": "ACTFC9237A9",
              "concurrencyStamp": "CS4D450CE1",
              "createdAt": new Date('2023-06-16T20:35:19.442636'),
              "description": "Activity description DE1D49573",
              "endTime": new Date('2023-03-29T23:53:12.562499'),
              "modifiedAt": new Date('2023-09-18T02:28:14.359313'),
              "name": "Activity N02D030E9",
              "startTime": new Date('2023-03-25T04:59:12.515233'),
              "userId": "U04C873FF"
            },
            {
              "activityId": "ACTB4F072B1",
              "concurrencyStamp": "CS5A6B0C42",
              "createdAt": new Date('2023-09-08T16:56:16.873724'),
              "description": "Activity description D5FC8C2FB",
              "endTime": new Date('2023-05-28T07:46:44.808084'),
              "modifiedAt": new Date('2023-07-24T21:08:38.841545'),
              "name": "Activity N8D5EDB33",
              "startTime": new Date('2023-07-11T14:13:27.605021'),
              "userId": "U849B49EC"
            },
            {
              "activityId": "ACTFDFD06BA",
              "concurrencyStamp": "CS98376CE9",
              "createdAt": new Date('2023-02-03T16:24:18.923602'),
              "description": "Activity description DD2A64205",
              "endTime": new Date('2023-12-05T09:14:40.009429'),
              "modifiedAt": new Date('2023-07-29T18:52:21.169798'),
              "name": "Activity N3CEC1599",
              "startTime": new Date('2023-07-29T23:24:01.907868'),
              "userId": "U38DA5F17"
            }
          ],
          "concurrencyStamp": "CS68475BED",
          "createdAt": new Date('2023-06-02T02:55:21.386511'),
          "description": "Job description D758852AC",
          "isExpanded": false,
          "jobId": "JOBA5CCBBA9",
          "modifiedAt": new Date('2023-11-19T21:52:25.663889'),
          "name": "Job Name N170E89DD",
          "userId": "UBB21BE3D"
        },
        {
          "activities": [
            {
              "activityId": "ACTD34FFC9C",
              "concurrencyStamp": "CS8854BB4B",
              "createdAt": new Date('2023-09-23T18:50:51.459172'),
              "description": "Activity description D2FC39A51",
              "endTime": new Date('2023-09-02T17:56:59.741713'),
              "modifiedAt": new Date('2023-05-17T08:48:15.452059'),
              "name": "Activity N6EBC85A9",
              "startTime": new Date('2023-11-24T02:00:31.733681'),
              "userId": "U20D51F0D"
            },
            {
              "activityId": "ACTE443A399",
              "concurrencyStamp": "CS33A68B03",
              "createdAt": new Date('2023-07-01T08:31:55.164383'),
              "description": "Activity description DD90553B5",
              "endTime": new Date('2023-06-04T13:26:52.670403'),
              "modifiedAt": new Date('2024-01-10T04:39:31.161737'),
              "name": "Activity N5611F4C9",
              "startTime": new Date('2023-05-13T15:28:36.855501'),
              "userId": "U90E7D47A"
            },
            {
              "activityId": "ACT69FBAB94",
              "concurrencyStamp": "CS6FD469F1",
              "createdAt": new Date('2023-06-13T17:01:15.274911'),
              "description": "Activity description D61189883",
              "endTime": new Date('2023-12-02T14:01:13.512480'),
              "modifiedAt": new Date('2024-01-12T16:57:51.227297'),
              "name": "Activity NBE448172",
              "startTime": new Date('2023-07-11T05:33:15.913690'),
              "userId": "U9E2A2BAA"
            },
            {
              "activityId": "ACT432CC8DE",
              "concurrencyStamp": "CSCBE3956A",
              "createdAt": new Date('2023-05-17T21:08:12.498893'),
              "description": "Activity description D628F2EDF",
              "endTime": new Date('2023-03-04T21:47:27.619794'),
              "modifiedAt": new Date('2024-01-18T04:03:47.801464'),
              "name": "Activity N3A8E455F",
              "startTime": new Date('2023-02-24T00:16:21.864634'),
              "userId": "U7D8F1D0F"
            },
            {
              "activityId": "ACT4E5AA4F4",
              "concurrencyStamp": "CSCA7D7B2B",
              "createdAt": new Date('2023-04-01T00:10:41.751159'),
              "description": "Activity description DFF91D6D2",
              "endTime": new Date('2023-10-07T09:12:30.273586'),
              "modifiedAt": new Date('2023-12-03T22:44:48.373464'),
              "name": "Activity NC42E1008",
              "startTime": new Date('2023-03-19T20:12:15.325294'),
              "userId": "UC306CCC6"
            }
          ],
          "concurrencyStamp": "CS5FE513A9",
          "createdAt": new Date('2023-11-20T12:11:45.614906'),
          "description": "Job description DBED5F95E",
          "isExpanded": false,
          "jobId": "JOBD05C85DA",
          "modifiedAt": new Date('2023-08-11T22:15:44.023947'),
          "name": "Job Name N766D1D21",
          "userId": "U2F9F458E"
        },
        {
          "activities": [
            {
              "activityId": "ACTB45A7B76",
              "concurrencyStamp": "CSA56E8068",
              "createdAt": new Date('2023-09-05T20:23:04.324238'),
              "description": "Activity description D04F554BD",
              "endTime": new Date('2023-02-05T21:15:07.611306'),
              "modifiedAt": new Date('2023-07-09T19:21:34.608185'),
              "name": "Activity N36026954",
              "startTime": new Date('2023-02-03T20:12:56.019076'),
              "userId": "U6E3848DE"
            },
            {
              "activityId": "ACTA8F6EECB",
              "concurrencyStamp": "CS31D2A7ED",
              "createdAt": new Date('2023-05-14T19:22:48.469862'),
              "description": "Activity description D68C96A0E",
              "endTime": new Date('2023-11-23T09:44:08.355122'),
              "modifiedAt": new Date('2023-10-24T02:31:05.135802'),
              "name": "Activity N188AA710",
              "startTime": new Date('2023-02-14T19:28:39.176520'),
              "userId": "UF01EC544"
            },
            {
              "activityId": "ACT2C9979B4",
              "concurrencyStamp": "CSA8CF53EA",
              "createdAt": new Date('2023-06-11T00:48:53.386120'),
              "description": "Activity description D66DD28D0",
              "endTime": new Date('2023-08-13T18:55:39.918644'),
              "modifiedAt": new Date('2023-02-16T15:33:35.861202'),
              "name": "Activity N589429A1",
              "startTime": new Date('2023-07-17T18:14:46.728691'),
              "userId": "UF23DB21B"
            },
            {
              "activityId": "ACT0A677FB5",
              "concurrencyStamp": "CSB0C398EF",
              "createdAt": new Date('2023-10-22T09:12:59.848638'),
              "description": "Activity description D96A6B04F",
              "endTime": new Date('2023-05-14T22:02:49.193256'),
              "modifiedAt": new Date('2023-07-17T23:53:22.054660'),
              "name": "Activity NEA0D8647",
              "startTime": new Date('2024-01-20T05:34:11.477810'),
              "userId": "U533FAC6E"
            }
          ],
          "concurrencyStamp": "CS139086FF",
          "createdAt": new Date('2023-03-20T13:01:35.068763'),
          "description": "Job description D95A9AE60",
          "isExpanded": false,
          "jobId": "JOBD0E0C0E9",
          "modifiedAt": new Date('2023-12-26T15:37:57.540751'),
          "name": "Job Name N3EF3D34D",
          "userId": "U8B9BCFD7"
        }
      ],
      "modifiedAt": new Date('2023-04-04T11:56:08.348643'),
      "name": "Category N3759B4B0",
      "status": 0,
      "userId": "UC390531E"
    },
    {
      "categoryId": "CAT05D3D9B3",
      "concurrencyStamp": "CSCCB89F28",
      "createdAt": new Date('2023-07-09T04:47:50.862708'),
      "description": "Category description D3297FA61",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT2872A526",
          "concurrencyStamp": "CS9F9C9710",
          "createdAt": new Date('2024-01-03T00:37:32.127852'),
          "description": "Activity description D4C2F7DD9",
          "endTime": new Date('2023-10-08T04:28:19.925893'),
          "modifiedAt": new Date('2023-02-07T12:59:36.773434'),
          "name": "Activity N5D54ADF8",
          "startTime": new Date('2023-08-01T07:58:15.897974'),
          "userId": "U5EBB22F4"
        },
        {
          "activityId": "ACT22B89F55",
          "concurrencyStamp": "CS49BB8FAC",
          "createdAt": new Date('2023-07-28T23:17:07.342751'),
          "description": "Activity description DF896E908",
          "endTime": new Date('2023-09-07T06:24:11.165044'),
          "modifiedAt": new Date('2023-03-07T19:42:27.656347'),
          "name": "Activity N35C4E76B",
          "startTime": new Date('2024-01-21T00:31:40.875634'),
          "userId": "UDE5DC0FB"
        },
        {
          "activityId": "ACT25691AB8",
          "concurrencyStamp": "CSCBB08AA1",
          "createdAt": new Date('2023-05-05T04:22:35.318608'),
          "description": "Activity description D486086CE",
          "endTime": new Date('2023-11-21T12:54:41.888389'),
          "modifiedAt": new Date('2023-02-01T20:11:02.005416'),
          "name": "Activity NB2A36DA8",
          "startTime": new Date('2023-10-14T00:25:26.425923'),
          "userId": "U4E7C0252"
        },
        {
          "activityId": "ACT1F8B2598",
          "concurrencyStamp": "CSDFFF1E89",
          "createdAt": new Date('2023-02-19T12:56:42.663699'),
          "description": "Activity description D6A046D50",
          "endTime": new Date('2023-09-04T00:02:08.358156'),
          "modifiedAt": new Date('2023-03-25T12:51:38.106234'),
          "name": "Activity N4AE74AF4",
          "startTime": new Date('2023-09-02T17:50:25.400874'),
          "userId": "UD637F395"
        },
        {
          "activityId": "ACT0253EAF4",
          "concurrencyStamp": "CS7E083F29",
          "createdAt": new Date('2023-03-12T19:41:50.111841'),
          "description": "Activity description D1E5C1614",
          "endTime": new Date('2023-09-29T00:46:30.760722'),
          "modifiedAt": new Date('2023-05-11T18:34:54.300489'),
          "name": "Activity N43454FE2",
          "startTime": new Date('2023-05-19T14:49:47.990858'),
          "userId": "UA98EF11C"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACTE62B8EF5",
              "concurrencyStamp": "CS877B0EA5",
              "createdAt": new Date('2023-11-24T15:52:39.927508'),
              "description": "Activity description D8CCE8064",
              "endTime": new Date('2023-11-19T16:18:44.010253'),
              "modifiedAt": new Date('2023-08-23T21:24:13.877540'),
              "name": "Activity N776C266F",
              "startTime": new Date('2023-12-30T08:38:26.458587'),
              "userId": "UAF817D7F"
            },
            {
              "activityId": "ACTE6A4AD0B",
              "concurrencyStamp": "CS9C76E42A",
              "createdAt": new Date('2024-01-24T13:19:11.801317'),
              "description": "Activity description DB1AA09BC",
              "endTime": new Date('2023-10-05T08:31:34.111930'),
              "modifiedAt": new Date('2023-05-05T21:14:12.670012'),
              "name": "Activity N4172947D",
              "startTime": new Date('2023-05-31T09:27:57.163815'),
              "userId": "UB2AE00BC"
            },
            {
              "activityId": "ACT863A834C",
              "concurrencyStamp": "CSCA3EB57F",
              "createdAt": new Date('2023-05-13T10:07:05.899538'),
              "description": "Activity description D09BDB39F",
              "endTime": new Date('2024-01-18T13:25:55.249208'),
              "modifiedAt": new Date('2023-08-03T01:42:22.851185'),
              "name": "Activity N5095D1AC",
              "startTime": new Date('2023-12-21T23:38:08.644065'),
              "userId": "U7199C92E"
            },
            {
              "activityId": "ACT55DE72A6",
              "concurrencyStamp": "CS150458B5",
              "createdAt": new Date('2023-03-05T22:44:40.973628'),
              "description": "Activity description D96919391",
              "endTime": new Date('2023-09-01T03:29:52.008152'),
              "modifiedAt": new Date('2023-09-26T03:45:30.905511'),
              "name": "Activity N0BBD0DEF",
              "startTime": new Date('2023-08-17T06:29:44.437027'),
              "userId": "U7B454A28"
            }
          ],
          "concurrencyStamp": "CSDAF3063D",
          "createdAt": new Date('2023-12-05T21:28:12.304682'),
          "description": "Job description DB92E6ABB",
          "isExpanded": false,
          "jobId": "JOBCCE7ED84",
          "modifiedAt": new Date('2023-05-20T19:22:25.430343'),
          "name": "Job Name N9995034E",
          "userId": "U97B12E01"
        },
        {
          "activities": [
            {
              "activityId": "ACTE8719AB4",
              "concurrencyStamp": "CS871ED29E",
              "createdAt": new Date('2023-06-11T09:13:52.497601'),
              "description": "Activity description DFBD8D9E0",
              "endTime": new Date('2023-08-16T19:08:01.147229'),
              "modifiedAt": new Date('2023-01-29T14:02:44.285453'),
              "name": "Activity NE14CCBBB",
              "startTime": new Date('2023-09-09T11:41:00.462499'),
              "userId": "UC70B7B6D"
            },
            {
              "activityId": "ACTCC2F0AD3",
              "concurrencyStamp": "CS30E82F47",
              "createdAt": new Date('2023-03-08T05:26:56.607799'),
              "description": "Activity description D8F705395",
              "endTime": new Date('2023-02-07T13:42:49.877683'),
              "modifiedAt": new Date('2024-01-03T23:55:42.113286'),
              "name": "Activity N9896491A",
              "startTime": new Date('2023-02-26T05:59:17.497910'),
              "userId": "U1A4B8F0E"
            },
            {
              "activityId": "ACTE0C41C75",
              "concurrencyStamp": "CS5991B49E",
              "createdAt": new Date('2023-04-03T02:58:15.101525'),
              "description": "Activity description D02CBF6E7",
              "endTime": new Date('2023-04-25T11:53:39.405073'),
              "modifiedAt": new Date('2023-06-12T17:59:20.340525'),
              "name": "Activity NA4B5F46F",
              "startTime": new Date('2023-07-12T05:27:20.949051'),
              "userId": "U11F17E18"
            }
          ],
          "concurrencyStamp": "CS83D7F473",
          "createdAt": new Date('2023-06-19T19:23:10.352597'),
          "description": "Job description D0713C513",
          "isExpanded": false,
          "jobId": "JOB77EC2161",
          "modifiedAt": new Date('2023-03-04T11:33:32.840093'),
          "name": "Job Name N5B2BFB9B",
          "userId": "UF90BFD3E"
        },
        {
          "activities": [
            {
              "activityId": "ACT218C16CA",
              "concurrencyStamp": "CS55B72148",
              "createdAt": new Date('2023-01-28T09:33:37.946398'),
              "description": "Activity description D06488BEC",
              "endTime": new Date('2023-03-26T00:20:57.271296'),
              "modifiedAt": new Date('2024-01-27T07:47:17.948823'),
              "name": "Activity N9971CABE",
              "startTime": new Date('2023-04-12T14:41:38.698921'),
              "userId": "UADBABAF3"
            },
            {
              "activityId": "ACTCE4D1745",
              "concurrencyStamp": "CSB8489559",
              "createdAt": new Date('2023-11-08T07:58:26.151459'),
              "description": "Activity description D4093674A",
              "endTime": new Date('2023-07-01T11:40:09.737937'),
              "modifiedAt": new Date('2023-02-12T00:44:17.735282'),
              "name": "Activity N9686223E",
              "startTime": new Date('2023-10-15T19:38:16.902349'),
              "userId": "U0A40CAFB"
            },
            {
              "activityId": "ACTD2F0D218",
              "concurrencyStamp": "CS5F84EFC8",
              "createdAt": new Date('2023-12-15T03:26:21.151058'),
              "description": "Activity description DE8A89B74",
              "endTime": new Date('2023-09-29T14:42:53.758610'),
              "modifiedAt": new Date('2023-05-20T03:22:53.730074'),
              "name": "Activity N6D5AF92B",
              "startTime": new Date('2023-02-07T20:10:09.274298'),
              "userId": "UBF9C77F1"
            }
          ],
          "concurrencyStamp": "CSA42FC88B",
          "createdAt": new Date('2023-03-31T10:56:49.142640'),
          "description": "Job description D8C362C9A",
          "isExpanded": false,
          "jobId": "JOB3323B701",
          "modifiedAt": new Date('2023-04-15T06:58:45.723329'),
          "name": "Job Name ND6B03FE0",
          "userId": "U6F45C706"
        },
        {
          "activities": [
            {
              "activityId": "ACTB36DACC4",
              "concurrencyStamp": "CS98E2735C",
              "createdAt": new Date('2023-06-01T23:11:47.205080'),
              "description": "Activity description D97CA5748",
              "endTime": new Date('2023-07-08T18:17:57.991745'),
              "modifiedAt": new Date('2023-12-29T18:37:35.830894'),
              "name": "Activity N5EA9CD41",
              "startTime": new Date('2023-03-02T11:58:34.626951'),
              "userId": "U7D328F83"
            },
            {
              "activityId": "ACT1E9B92EF",
              "concurrencyStamp": "CS167DC327",
              "createdAt": new Date('2023-08-30T11:15:56.926680'),
              "description": "Activity description D48103D9C",
              "endTime": new Date('2023-04-13T20:26:27.486271'),
              "modifiedAt": new Date('2023-01-29T22:49:45.240298'),
              "name": "Activity N66CB5417",
              "startTime": new Date('2023-08-06T14:34:36.202920'),
              "userId": "U47674824"
            },
            {
              "activityId": "ACT7C3F473D",
              "concurrencyStamp": "CS109D3940",
              "createdAt": new Date('2023-05-08T04:38:36.888788'),
              "description": "Activity description D19ABE24F",
              "endTime": new Date('2023-09-22T13:29:16.376005'),
              "modifiedAt": new Date('2023-05-02T12:57:11.970342'),
              "name": "Activity N2391000C",
              "startTime": new Date('2024-01-17T17:27:39.616595'),
              "userId": "U8A7F6EFC"
            },
            {
              "activityId": "ACT2D361190",
              "concurrencyStamp": "CSC44EE091",
              "createdAt": new Date('2023-08-03T15:18:41.658699'),
              "description": "Activity description DC00C40A9",
              "endTime": new Date('2023-08-31T19:50:43.098076'),
              "modifiedAt": new Date('2023-08-28T05:56:44.639785'),
              "name": "Activity NDAB42FE1",
              "startTime": new Date('2023-07-08T05:34:16.873433'),
              "userId": "UEDF7344A"
            }
          ],
          "concurrencyStamp": "CSECAE099C",
          "createdAt": new Date('2023-12-23T20:34:00.879146'),
          "description": "Job description D027E6E70",
          "isExpanded": false,
          "jobId": "JOB341D8835",
          "modifiedAt": new Date('2023-05-11T10:57:12.791315'),
          "name": "Job Name NCB9E6520",
          "userId": "U3FF57790"
        }
      ],
      "modifiedAt": new Date('2023-10-05T23:39:08.821821'),
      "name": "Category NEA14D006",
      "status": 5,
      "userId": "UBF80B513"
    },
    {
      "categoryId": "CAT249B1C55",
      "concurrencyStamp": "CS6C5F707F",
      "createdAt": new Date('2023-11-23T06:41:31.895960'),
      "description": "Category description DF2598FC5",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT7C356425",
          "concurrencyStamp": "CS40B22858",
          "createdAt": new Date('2023-09-08T12:04:52.704690'),
          "description": "Activity description DAA30F7C4",
          "endTime": new Date('2023-08-02T23:11:16.600758'),
          "modifiedAt": new Date('2023-07-21T09:10:46.299934'),
          "name": "Activity NC63E53EE",
          "startTime": new Date('2023-09-23T12:43:07.728785'),
          "userId": "UDA5E40A7"
        },
        {
          "activityId": "ACTBF23C2A8",
          "concurrencyStamp": "CS06D03195",
          "createdAt": new Date('2023-04-02T07:19:26.628926'),
          "description": "Activity description DB102C5D3",
          "endTime": new Date('2023-12-10T15:27:32.294347'),
          "modifiedAt": new Date('2024-01-03T07:56:07.324702'),
          "name": "Activity NCFC0C948",
          "startTime": new Date('2023-03-08T17:15:13.040686'),
          "userId": "U00A4D1D9"
        },
        {
          "activityId": "ACT758D7F4B",
          "concurrencyStamp": "CS12DC6237",
          "createdAt": new Date('2023-01-29T13:55:27.642871'),
          "description": "Activity description D2CCD078E",
          "endTime": new Date('2023-10-25T07:17:04.379954'),
          "modifiedAt": new Date('2023-07-10T20:56:00.609730'),
          "name": "Activity NFCCC259D",
          "startTime": new Date('2023-11-17T12:12:00.176869'),
          "userId": "U8304E1C6"
        },
        {
          "activityId": "ACT2A76D3D4",
          "concurrencyStamp": "CS8F6D61CB",
          "createdAt": new Date('2023-03-05T00:20:51.149471'),
          "description": "Activity description D6EC32A17",
          "endTime": new Date('2023-05-27T18:41:09.121779'),
          "modifiedAt": new Date('2023-04-27T15:14:49.769175'),
          "name": "Activity N0F2E36A7",
          "startTime": new Date('2023-07-11T17:03:35.352927'),
          "userId": "UD5887E75"
        },
        {
          "activityId": "ACT82CE3203",
          "concurrencyStamp": "CS4A415046",
          "createdAt": new Date('2023-10-10T15:43:11.151893'),
          "description": "Activity description D6D8F6B5A",
          "endTime": new Date('2023-02-04T23:33:32.191003'),
          "modifiedAt": new Date('2023-08-31T10:13:28.443296'),
          "name": "Activity N3C6135C5",
          "startTime": new Date('2023-12-18T14:06:08.073885'),
          "userId": "U31129252"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT65BE249A",
              "concurrencyStamp": "CS0E124114",
              "createdAt": new Date('2023-05-03T05:59:54.698863'),
              "description": "Activity description D1B4DB353",
              "endTime": new Date('2023-09-10T15:06:01.565410'),
              "modifiedAt": new Date('2023-10-09T10:50:57.355244'),
              "name": "Activity N20127533",
              "startTime": new Date('2023-02-10T10:30:38.029484'),
              "userId": "UF5AA6CB0"
            },
            {
              "activityId": "ACTBE50415D",
              "concurrencyStamp": "CSD2D46D50",
              "createdAt": new Date('2023-05-22T22:49:59.426912'),
              "description": "Activity description DAC6D1596",
              "endTime": new Date('2024-01-07T09:46:10.856753'),
              "modifiedAt": new Date('2023-11-20T16:57:26.830475'),
              "name": "Activity N1C735910",
              "startTime": new Date('2023-10-16T21:09:39.578998'),
              "userId": "U2C5B5B77"
            },
            {
              "activityId": "ACT3D0866D2",
              "concurrencyStamp": "CSDD26BB1F",
              "createdAt": new Date('2023-04-05T06:20:11.588811'),
              "description": "Activity description D50F49DEA",
              "endTime": new Date('2023-10-24T03:15:05.298070'),
              "modifiedAt": new Date('2023-12-10T03:50:27.462791'),
              "name": "Activity N8419CC9B",
              "startTime": new Date('2023-02-09T06:42:12.701487'),
              "userId": "U1C27A7BD"
            },
            {
              "activityId": "ACT6730386B",
              "concurrencyStamp": "CS5065E16A",
              "createdAt": new Date('2023-09-15T02:22:17.646199'),
              "description": "Activity description D50A636B3",
              "endTime": new Date('2023-06-21T08:02:30.001014'),
              "modifiedAt": new Date('2023-12-15T07:41:53.799168'),
              "name": "Activity N93AFF055",
              "startTime": new Date('2023-03-03T09:52:37.854281'),
              "userId": "U29045AE9"
            }
          ],
          "concurrencyStamp": "CSCCACC837",
          "createdAt": new Date('2023-09-22T09:50:03.269993'),
          "description": "Job description DF7F75DE4",
          "isExpanded": false,
          "jobId": "JOBC8798159",
          "modifiedAt": new Date('2023-09-18T05:47:00.595582'),
          "name": "Job Name N691CBA17",
          "userId": "U1599E179"
        },
        {
          "activities": [
            {
              "activityId": "ACTA5509226",
              "concurrencyStamp": "CS158C0FD6",
              "createdAt": new Date('2023-10-31T11:44:01.099644'),
              "description": "Activity description DE13FB51E",
              "endTime": new Date('2023-08-08T10:12:13.020407'),
              "modifiedAt": new Date('2023-09-27T16:12:37.684730'),
              "name": "Activity N61DDFDEC",
              "startTime": new Date('2023-11-07T15:36:14.128292'),
              "userId": "U42F73B66"
            },
            {
              "activityId": "ACT7FE0110B",
              "concurrencyStamp": "CS6ADBE50C",
              "createdAt": new Date('2023-09-25T12:14:27.562467'),
              "description": "Activity description DD322BD65",
              "endTime": new Date('2023-06-19T20:20:17.336992'),
              "modifiedAt": new Date('2024-01-19T02:50:44.824281'),
              "name": "Activity N15B4E447",
              "startTime": new Date('2023-04-11T15:06:19.540926'),
              "userId": "U02E7D829"
            },
            {
              "activityId": "ACT86D7D36E",
              "concurrencyStamp": "CSBB242AB2",
              "createdAt": new Date('2023-03-14T18:59:02.790907'),
              "description": "Activity description D55EB2436",
              "endTime": new Date('2023-11-04T05:54:40.606293'),
              "modifiedAt": new Date('2023-05-12T03:49:18.148823'),
              "name": "Activity ND4AA9854",
              "startTime": new Date('2024-01-07T23:27:39.522367'),
              "userId": "UCF68BD74"
            }
          ],
          "concurrencyStamp": "CS2E4C16E7",
          "createdAt": new Date('2024-01-01T11:55:50.346493'),
          "description": "Job description D4A6A8E3D",
          "isExpanded": false,
          "jobId": "JOBEA22DEC4",
          "modifiedAt": new Date('2023-05-04T06:11:36.960494'),
          "name": "Job Name NB0790B25",
          "userId": "U236ABB10"
        },
        {
          "activities": [
            {
              "activityId": "ACT271473A9",
              "concurrencyStamp": "CSD6D469BE",
              "createdAt": new Date('2023-08-11T15:57:22.094989'),
              "description": "Activity description DD1EEDDE8",
              "endTime": new Date('2023-08-05T03:52:15.980134'),
              "modifiedAt": new Date('2023-08-25T19:15:37.151200'),
              "name": "Activity N43A33800",
              "startTime": new Date('2023-04-29T00:01:04.484579'),
              "userId": "U17660C35"
            },
            {
              "activityId": "ACT665C6ACB",
              "concurrencyStamp": "CSF4DF6DAD",
              "createdAt": new Date('2023-05-28T14:30:35.516508'),
              "description": "Activity description DD9024B77",
              "endTime": new Date('2023-05-11T16:40:40.215259'),
              "modifiedAt": new Date('2023-07-08T01:13:09.852194'),
              "name": "Activity N51384CB2",
              "startTime": new Date('2023-02-18T20:07:32.680302'),
              "userId": "U7F21AFC7"
            },
            {
              "activityId": "ACT1502E660",
              "concurrencyStamp": "CS676CAD60",
              "createdAt": new Date('2023-08-28T14:10:11.567418'),
              "description": "Activity description D9E56EC29",
              "endTime": new Date('2023-09-16T14:04:31.245885'),
              "modifiedAt": new Date('2023-01-31T03:33:02.468739'),
              "name": "Activity N77276F37",
              "startTime": new Date('2023-12-18T00:59:16.779500'),
              "userId": "U3134DCC1"
            },
            {
              "activityId": "ACT48B0EC2E",
              "concurrencyStamp": "CS9F7AD8C4",
              "createdAt": new Date('2023-03-30T11:25:52.893461'),
              "description": "Activity description D5216752D",
              "endTime": new Date('2023-03-04T14:20:26.539304'),
              "modifiedAt": new Date('2023-06-03T02:02:38.302964'),
              "name": "Activity N5317C865",
              "startTime": new Date('2023-09-28T07:19:17.378636'),
              "userId": "U8779810E"
            },
            {
              "activityId": "ACT5AE04271",
              "concurrencyStamp": "CS91F023EA",
              "createdAt": new Date('2023-08-30T04:45:22.102550'),
              "description": "Activity description D912DBE61",
              "endTime": new Date('2023-04-23T14:00:11.732055'),
              "modifiedAt": new Date('2023-07-12T14:40:45.123131'),
              "name": "Activity N73F23C60",
              "startTime": new Date('2024-01-07T17:49:46.932457'),
              "userId": "U57337E37"
            }
          ],
          "concurrencyStamp": "CS1926B59F",
          "createdAt": new Date('2023-08-09T15:29:50.778235'),
          "description": "Job description DAF978016",
          "isExpanded": false,
          "jobId": "JOB76A4F0F9",
          "modifiedAt": new Date('2023-02-11T23:23:28.958992'),
          "name": "Job Name NA8B974B8",
          "userId": "U9C10F461"
        }
      ],
      "modifiedAt": new Date('2023-09-17T21:38:30.504733'),
      "name": "Category NDE781BF7",
      "status": 5,
      "userId": "UDAD8B1C2"
    },
    {
      "categoryId": "CAT0FA28EED",
      "concurrencyStamp": "CS7EB79216",
      "createdAt": new Date('2023-10-22T06:20:13.861317'),
      "description": "Category description D5EFD51C4",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACTCADEB911",
          "concurrencyStamp": "CSAF4B423B",
          "createdAt": new Date('2023-11-19T00:15:16.460499'),
          "description": "Activity description D2D5603C3",
          "endTime": new Date('2023-03-03T17:16:16.895914'),
          "modifiedAt": new Date('2023-11-27T05:48:51.587208'),
          "name": "Activity N44281ED8",
          "startTime": new Date('2023-11-10T14:54:31.945931'),
          "userId": "U018DA010"
        },
        {
          "activityId": "ACT3A44966A",
          "concurrencyStamp": "CS171D3989",
          "createdAt": new Date('2023-08-30T11:10:13.246362'),
          "description": "Activity description D2F87851C",
          "endTime": new Date('2023-02-10T04:52:26.531061'),
          "modifiedAt": new Date('2023-05-15T07:28:34.969125'),
          "name": "Activity N360AD20C",
          "startTime": new Date('2023-11-25T10:55:46.771318'),
          "userId": "U24D387F9"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT72C083A2",
              "concurrencyStamp": "CSBEE0557C",
              "createdAt": new Date('2023-09-18T07:19:19.947176'),
              "description": "Activity description DE96D2240",
              "endTime": new Date('2023-04-29T12:18:25.793857'),
              "modifiedAt": new Date('2023-05-05T06:15:03.357235'),
              "name": "Activity N9440B659",
              "startTime": new Date('2024-01-24T23:07:09.197792'),
              "userId": "U2A634929"
            },
            {
              "activityId": "ACT9828FEC7",
              "concurrencyStamp": "CS8E391048",
              "createdAt": new Date('2023-08-10T20:27:30.031726'),
              "description": "Activity description D5793031C",
              "endTime": new Date('2023-06-10T15:52:05.530885'),
              "modifiedAt": new Date('2023-03-12T18:07:49.398752'),
              "name": "Activity N51866D4C",
              "startTime": new Date('2023-06-17T05:40:18.402737'),
              "userId": "UA6FEF28D"
            }
          ],
          "concurrencyStamp": "CSB365DCD3",
          "createdAt": new Date('2023-08-16T22:15:29.321090'),
          "description": "Job description D4871CAC1",
          "isExpanded": false,
          "jobId": "JOB8ECB6A3E",
          "modifiedAt": new Date('2023-04-28T20:08:46.637777'),
          "name": "Job Name ND54E1EE2",
          "userId": "UEF59FAA7"
        },
        {
          "activities": [
            {
              "activityId": "ACTDBCA6F82",
              "concurrencyStamp": "CS9A6A1AD6",
              "createdAt": new Date('2023-10-09T02:32:07.273641'),
              "description": "Activity description D620711B9",
              "endTime": new Date('2024-01-17T16:08:20.310165'),
              "modifiedAt": new Date('2023-11-06T19:29:55.930821'),
              "name": "Activity N96B9369B",
              "startTime": new Date('2023-03-23T15:02:29.602176'),
              "userId": "U65899E70"
            },
            {
              "activityId": "ACT607E6D6E",
              "concurrencyStamp": "CS6EB1243B",
              "createdAt": new Date('2023-09-24T21:22:48.333695'),
              "description": "Activity description D52AFD3F4",
              "endTime": new Date('2023-11-05T22:58:44.946063'),
              "modifiedAt": new Date('2023-07-11T08:38:00.023783'),
              "name": "Activity NB292CDD5",
              "startTime": new Date('2023-03-24T07:26:41.153278'),
              "userId": "UBF9C1CE5"
            },
            {
              "activityId": "ACTD778587D",
              "concurrencyStamp": "CS7CF1742A",
              "createdAt": new Date('2023-10-27T23:58:02.365612'),
              "description": "Activity description DBA4EB583",
              "endTime": new Date('2023-09-13T13:39:11.628190'),
              "modifiedAt": new Date('2023-08-07T16:44:23.111238'),
              "name": "Activity ND6C7EAA1",
              "startTime": new Date('2023-07-18T08:34:01.912522'),
              "userId": "U7FB74086"
            },
            {
              "activityId": "ACTD884C715",
              "concurrencyStamp": "CS81DC645A",
              "createdAt": new Date('2023-10-27T18:49:19.335795'),
              "description": "Activity description D11715A6E",
              "endTime": new Date('2023-10-27T12:17:26.661485'),
              "modifiedAt": new Date('2023-08-10T21:53:37.610051'),
              "name": "Activity ND7F4552F",
              "startTime": new Date('2024-01-19T05:28:27.884838'),
              "userId": "U61D2E0B1"
            },
            {
              "activityId": "ACTC95E74A7",
              "concurrencyStamp": "CSE8E811D1",
              "createdAt": new Date('2023-11-30T15:11:01.010436'),
              "description": "Activity description DFF97A7E8",
              "endTime": new Date('2023-03-18T12:23:02.428859'),
              "modifiedAt": new Date('2023-09-26T04:10:16.203939'),
              "name": "Activity N8922AAD0",
              "startTime": new Date('2023-07-10T05:43:37.613355'),
              "userId": "U48A53330"
            }
          ],
          "concurrencyStamp": "CS3D10CF1A",
          "createdAt": new Date('2023-12-13T03:28:11.982358'),
          "description": "Job description D8B41B73F",
          "isExpanded": false,
          "jobId": "JOB986B360B",
          "modifiedAt": new Date('2023-08-24T23:03:38.734096'),
          "name": "Job Name N94DEEC76",
          "userId": "UAB28890D"
        },
        {
          "activities": [
            {
              "activityId": "ACT02DC4E6F",
              "concurrencyStamp": "CS4A8907FA",
              "createdAt": new Date('2023-11-05T10:31:26.130640'),
              "description": "Activity description DA4A92D58",
              "endTime": new Date('2024-01-26T09:47:36.835582'),
              "modifiedAt": new Date('2023-08-04T04:30:25.089742'),
              "name": "Activity N018DB64A",
              "startTime": new Date('2023-06-27T12:07:30.012488'),
              "userId": "U139CD0DA"
            },
            {
              "activityId": "ACT89F71E66",
              "concurrencyStamp": "CSE3B57BB8",
              "createdAt": new Date('2023-02-10T03:05:56.203433'),
              "description": "Activity description DA943A9E6",
              "endTime": new Date('2023-05-22T10:53:28.425167'),
              "modifiedAt": new Date('2023-06-04T22:19:12.736628'),
              "name": "Activity N8AC4CA31",
              "startTime": new Date('2023-08-13T14:46:40.928371'),
              "userId": "UDFC93354"
            },
            {
              "activityId": "ACTB8440399",
              "concurrencyStamp": "CSECFC144C",
              "createdAt": new Date('2023-08-23T01:28:45.230437'),
              "description": "Activity description D90179829",
              "endTime": new Date('2023-04-30T16:48:52.246278'),
              "modifiedAt": new Date('2023-08-03T18:56:16.578838'),
              "name": "Activity NA624826D",
              "startTime": new Date('2023-11-16T08:59:00.376533'),
              "userId": "UD71B4FAF"
            }
          ],
          "concurrencyStamp": "CSA40904C7",
          "createdAt": new Date('2023-07-13T15:49:14.316140'),
          "description": "Job description DEE653EF1",
          "isExpanded": false,
          "jobId": "JOB68B5CC8A",
          "modifiedAt": new Date('2023-07-15T08:11:33.819600'),
          "name": "Job Name ND4DB58E9",
          "userId": "UB9E97E89"
        },
        {
          "activities": [
            {
              "activityId": "ACT11C1D7B5",
              "concurrencyStamp": "CS821DB41C",
              "createdAt": new Date('2023-12-17T04:28:33.595862'),
              "description": "Activity description D662A6BA8",
              "endTime": new Date('2023-10-06T06:12:15.716649'),
              "modifiedAt": new Date('2023-07-15T00:14:46.164926'),
              "name": "Activity NFBD7B9F6",
              "startTime": new Date('2023-11-28T23:46:52.722142'),
              "userId": "U2942AD2E"
            },
            {
              "activityId": "ACT91E2DEA4",
              "concurrencyStamp": "CSC9D457E4",
              "createdAt": new Date('2023-04-08T04:08:32.956670'),
              "description": "Activity description D9C665A28",
              "endTime": new Date('2024-01-02T08:30:17.595351'),
              "modifiedAt": new Date('2023-06-13T02:48:28.051987'),
              "name": "Activity N1EC1AEE6",
              "startTime": new Date('2023-01-28T07:38:58.350410'),
              "userId": "UE738C529"
            },
            {
              "activityId": "ACT5D0F060D",
              "concurrencyStamp": "CSA0F467B4",
              "createdAt": new Date('2023-05-06T00:24:35.256786'),
              "description": "Activity description D9A7EE4FA",
              "endTime": new Date('2023-05-26T19:31:39.741406'),
              "modifiedAt": new Date('2023-10-29T03:03:34.450260'),
              "name": "Activity NF04CABA9",
              "startTime": new Date('2024-01-18T10:50:43.866611'),
              "userId": "U2CD7A4D8"
            },
            {
              "activityId": "ACT23A665CF",
              "concurrencyStamp": "CS49841EC4",
              "createdAt": new Date('2023-03-28T23:50:14.196577'),
              "description": "Activity description DB7C081B1",
              "endTime": new Date('2023-03-06T22:27:37.744447'),
              "modifiedAt": new Date('2023-11-19T07:37:15.713925'),
              "name": "Activity N5B04E2BA",
              "startTime": new Date('2023-11-21T13:54:17.868233'),
              "userId": "U611B84A9"
            }
          ],
          "concurrencyStamp": "CSD6C77139",
          "createdAt": new Date('2023-09-08T10:29:56.915849'),
          "description": "Job description DCA96486A",
          "isExpanded": false,
          "jobId": "JOB32507581",
          "modifiedAt": new Date('2024-01-20T04:13:33.845695'),
          "name": "Job Name NFCBAF86B",
          "userId": "U1C0BA82A"
        },
        {
          "activities": [
            {
              "activityId": "ACT34A4D488",
              "concurrencyStamp": "CS6F8A4695",
              "createdAt": new Date('2023-04-15T19:33:46.523233'),
              "description": "Activity description D84BF1E43",
              "endTime": new Date('2023-04-19T23:27:18.123955'),
              "modifiedAt": new Date('2023-09-26T18:10:01.650024'),
              "name": "Activity NBA0723B0",
              "startTime": new Date('2024-01-25T02:24:04.345594'),
              "userId": "UE9417448"
            },
            {
              "activityId": "ACTA763ED91",
              "concurrencyStamp": "CSBA3F0918",
              "createdAt": new Date('2023-11-07T18:18:27.245248'),
              "description": "Activity description D40EC375B",
              "endTime": new Date('2023-07-28T09:58:54.345849'),
              "modifiedAt": new Date('2023-03-02T19:34:07.817731'),
              "name": "Activity N3A430350",
              "startTime": new Date('2023-04-01T18:28:04.548073'),
              "userId": "U8E6F8CD8"
            },
            {
              "activityId": "ACT691C2621",
              "concurrencyStamp": "CS41D0A333",
              "createdAt": new Date('2023-10-22T02:56:31.201939'),
              "description": "Activity description D0269C78B",
              "endTime": new Date('2023-06-12T13:40:17.048153'),
              "modifiedAt": new Date('2024-01-04T19:01:29.288991'),
              "name": "Activity N964D580A",
              "startTime": new Date('2023-09-03T01:55:44.792180'),
              "userId": "U8F43D194"
            },
            {
              "activityId": "ACTA5CA025C",
              "concurrencyStamp": "CS70664234",
              "createdAt": new Date('2023-09-08T02:02:44.939497'),
              "description": "Activity description DC31C9021",
              "endTime": new Date('2023-07-06T23:39:47.161852'),
              "modifiedAt": new Date('2023-12-21T13:56:22.520419'),
              "name": "Activity NF5F377BD",
              "startTime": new Date('2023-09-03T07:18:14.297826'),
              "userId": "U2DDFCDB3"
            },
            {
              "activityId": "ACT768C0410",
              "concurrencyStamp": "CS8EBCE0FE",
              "createdAt": new Date('2023-09-09T19:54:52.498107'),
              "description": "Activity description DE2851AA1",
              "endTime": new Date('2023-04-07T09:55:54.867819'),
              "modifiedAt": new Date('2023-12-29T01:55:11.227987'),
              "name": "Activity N72C70233",
              "startTime": new Date('2024-01-24T04:08:07.181949'),
              "userId": "U47A1F3C0"
            }
          ],
          "concurrencyStamp": "CS15350070",
          "createdAt": new Date('2023-04-22T10:37:03.731566'),
          "description": "Job description D18DE5383",
          "isExpanded": false,
          "jobId": "JOBF9C54B5D",
          "modifiedAt": new Date('2023-11-29T03:05:40.002563'),
          "name": "Job Name NCC13EE98",
          "userId": "U9BCD6160"
        }
      ],
      "modifiedAt": new Date('2023-07-12T19:55:16.971815'),
      "name": "Category NB1EE4353",
      "status": 1,
      "userId": "U4BAC27A9"
    },
    {
      "categoryId": "CAT2BF57BDA",
      "concurrencyStamp": "CS42CB6EE7",
      "createdAt": new Date('2023-07-30T05:43:11.825899'),
      "description": "Category description DFAC46E31",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT20D9885B",
          "concurrencyStamp": "CSD386F728",
          "createdAt": new Date('2023-11-28T11:55:34.354565'),
          "description": "Activity description D47D47368",
          "endTime": new Date('2023-07-10T14:33:09.204358'),
          "modifiedAt": new Date('2023-12-26T01:37:20.205300'),
          "name": "Activity NC3123D20",
          "startTime": new Date('2023-09-25T04:11:24.298639'),
          "userId": "U86BEBC0F"
        },
        {
          "activityId": "ACTDCBC541B",
          "concurrencyStamp": "CS2B53DAE4",
          "createdAt": new Date('2023-11-19T13:03:44.450383'),
          "description": "Activity description D7546A966",
          "endTime": new Date('2023-01-31T02:12:52.361027'),
          "modifiedAt": new Date('2023-05-11T22:58:51.706051'),
          "name": "Activity N5607E29B",
          "startTime": new Date('2023-07-22T18:42:35.834472'),
          "userId": "U6A3765DC"
        },
        {
          "activityId": "ACT17A86CE5",
          "concurrencyStamp": "CSFA271F97",
          "createdAt": new Date('2023-10-11T08:36:24.787101'),
          "description": "Activity description DFF7E3C3E",
          "endTime": new Date('2023-02-12T12:32:36.134762'),
          "modifiedAt": new Date('2023-08-15T04:39:08.037727'),
          "name": "Activity N4BD759F7",
          "startTime": new Date('2023-10-14T03:06:09.778389'),
          "userId": "UAD0709B3"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT4CF1637D",
              "concurrencyStamp": "CS9FBB12DA",
              "createdAt": new Date('2023-02-03T14:15:37.688146'),
              "description": "Activity description D2309E22A",
              "endTime": new Date('2023-08-31T21:33:39.241474'),
              "modifiedAt": new Date('2023-06-17T02:01:48.677586'),
              "name": "Activity N5C3738DE",
              "startTime": new Date('2023-09-21T01:42:37.463359'),
              "userId": "U9CAE9C14"
            },
            {
              "activityId": "ACTC5508B7A",
              "concurrencyStamp": "CS08AD4A5F",
              "createdAt": new Date('2023-04-15T13:17:45.425201'),
              "description": "Activity description DECAF91A9",
              "endTime": new Date('2023-05-29T04:39:04.312945'),
              "modifiedAt": new Date('2023-10-17T09:23:30.630790'),
              "name": "Activity N8F53338D",
              "startTime": new Date('2023-10-10T10:14:56.179371'),
              "userId": "UA94FAADF"
            }
          ],
          "concurrencyStamp": "CSA8706188",
          "createdAt": new Date('2023-10-21T13:42:31.642886'),
          "description": "Job description DF5873BF0",
          "isExpanded": false,
          "jobId": "JOBEAFC83CB",
          "modifiedAt": new Date('2023-03-05T22:12:16.828704'),
          "name": "Job Name N9743E0C8",
          "userId": "U1175DAF0"
        },
        {
          "activities": [
            {
              "activityId": "ACT4BFD4CF4",
              "concurrencyStamp": "CS743E3DE2",
              "createdAt": new Date('2023-08-11T08:24:31.150500'),
              "description": "Activity description DB2152C8A",
              "endTime": new Date('2023-03-10T15:04:46.020261'),
              "modifiedAt": new Date('2023-12-07T09:42:45.036060'),
              "name": "Activity N4BD3D118",
              "startTime": new Date('2023-12-12T10:17:09.278602'),
              "userId": "U03A54235"
            },
            {
              "activityId": "ACT7C906370",
              "concurrencyStamp": "CS861946F9",
              "createdAt": new Date('2024-01-08T07:24:39.084134'),
              "description": "Activity description DD5C647BD",
              "endTime": new Date('2023-08-23T21:39:41.096326'),
              "modifiedAt": new Date('2023-06-28T11:28:49.795533'),
              "name": "Activity NEE046C79",
              "startTime": new Date('2023-02-19T17:42:43.859463'),
              "userId": "U1EBC90CA"
            },
            {
              "activityId": "ACTB803F4CC",
              "concurrencyStamp": "CS0E304651",
              "createdAt": new Date('2023-06-15T07:29:38.422320'),
              "description": "Activity description D7E6E2C46",
              "endTime": new Date('2023-06-18T16:57:14.842141'),
              "modifiedAt": new Date('2023-03-08T14:03:59.710928'),
              "name": "Activity N793002D0",
              "startTime": new Date('2023-04-12T00:32:24.269394'),
              "userId": "U1D4E8540"
            },
            {
              "activityId": "ACT395242E1",
              "concurrencyStamp": "CS3216A1E1",
              "createdAt": new Date('2023-03-23T02:15:09.155369'),
              "description": "Activity description D1C28B119",
              "endTime": new Date('2023-07-22T08:30:41.666100'),
              "modifiedAt": new Date('2023-06-05T05:14:13.889020'),
              "name": "Activity N67D89DA8",
              "startTime": new Date('2023-09-06T17:01:50.604565'),
              "userId": "U288E9570"
            }
          ],
          "concurrencyStamp": "CS8D620B2A",
          "createdAt": new Date('2023-06-10T00:46:58.021042'),
          "description": "Job description DB04DFD3C",
          "isExpanded": false,
          "jobId": "JOB4161A704",
          "modifiedAt": new Date('2023-04-10T22:41:17.198374'),
          "name": "Job Name N3268CE8F",
          "userId": "UCBB6DB78"
        },
        {
          "activities": [
            {
              "activityId": "ACTEB36156C",
              "concurrencyStamp": "CS5FC935CD",
              "createdAt": new Date('2023-10-26T13:21:33.613418'),
              "description": "Activity description DB51C1190",
              "endTime": new Date('2023-07-26T01:54:52.346419'),
              "modifiedAt": new Date('2024-01-13T08:42:58.454505'),
              "name": "Activity N6CB2F408",
              "startTime": new Date('2024-01-02T17:11:11.578320'),
              "userId": "U8803F9D6"
            },
            {
              "activityId": "ACTCE4CA963",
              "concurrencyStamp": "CS3D147DB8",
              "createdAt": new Date('2023-05-04T04:14:25.718635'),
              "description": "Activity description D70C38F09",
              "endTime": new Date('2023-04-18T20:12:42.832657'),
              "modifiedAt": new Date('2023-03-27T15:11:18.732456'),
              "name": "Activity NE3B6683E",
              "startTime": new Date('2023-12-06T01:58:18.897004'),
              "userId": "U9E8C8D1D"
            },
            {
              "activityId": "ACT5B656DD1",
              "concurrencyStamp": "CS365C07D8",
              "createdAt": new Date('2023-07-01T12:42:40.037610'),
              "description": "Activity description DC69C9461",
              "endTime": new Date('2023-02-12T16:01:32.283835'),
              "modifiedAt": new Date('2023-09-09T19:02:05.954393'),
              "name": "Activity NAC96956A",
              "startTime": new Date('2023-02-06T01:32:03.352493'),
              "userId": "UB60341CC"
            },
            {
              "activityId": "ACTEAE29512",
              "concurrencyStamp": "CSD3288323",
              "createdAt": new Date('2023-03-11T11:32:18.007676'),
              "description": "Activity description D8B6C390D",
              "endTime": new Date('2023-11-19T09:28:28.361869'),
              "modifiedAt": new Date('2023-11-29T20:15:24.804872'),
              "name": "Activity NC962A1EC",
              "startTime": new Date('2023-11-18T00:02:08.574727'),
              "userId": "UC9143B4C"
            },
            {
              "activityId": "ACT53B84F44",
              "concurrencyStamp": "CS43FF46F6",
              "createdAt": new Date('2023-07-10T18:57:20.534131'),
              "description": "Activity description D4A703F73",
              "endTime": new Date('2023-09-01T22:49:24.361548'),
              "modifiedAt": new Date('2023-06-26T14:59:12.303205'),
              "name": "Activity N6B85EA66",
              "startTime": new Date('2024-01-07T22:53:04.029617'),
              "userId": "U84FC523C"
            }
          ],
          "concurrencyStamp": "CS6C6C33C3",
          "createdAt": new Date('2023-02-26T21:12:33.840125'),
          "description": "Job description DCCBB4D2B",
          "isExpanded": false,
          "jobId": "JOBDDCC2568",
          "modifiedAt": new Date('2023-10-17T11:11:51.978321'),
          "name": "Job Name N40A8D037",
          "userId": "U707E90DE"
        },
        {
          "activities": [
            {
              "activityId": "ACT881C29A7",
              "concurrencyStamp": "CSCBF3E385",
              "createdAt": new Date('2023-07-01T10:58:31.416150'),
              "description": "Activity description D4446C844",
              "endTime": new Date('2024-01-01T06:04:02.637563'),
              "modifiedAt": new Date('2023-08-08T01:25:26.939317'),
              "name": "Activity N737B8DA3",
              "startTime": new Date('2023-07-11T13:27:17.564955'),
              "userId": "U3502BD25"
            },
            {
              "activityId": "ACTBFB22321",
              "concurrencyStamp": "CS3F35C6AF",
              "createdAt": new Date('2023-03-30T18:25:08.472217'),
              "description": "Activity description D13E2EEDB",
              "endTime": new Date('2024-01-15T04:20:23.892696'),
              "modifiedAt": new Date('2023-09-18T13:20:36.215678'),
              "name": "Activity NDF0CF0F2",
              "startTime": new Date('2023-11-27T10:32:41.886315'),
              "userId": "UEF11ED22"
            }
          ],
          "concurrencyStamp": "CSC7D3A814",
          "createdAt": new Date('2023-08-06T10:22:12.501478'),
          "description": "Job description D0AEE61C4",
          "isExpanded": false,
          "jobId": "JOB82066161",
          "modifiedAt": new Date('2023-03-14T15:37:05.839775'),
          "name": "Job Name N796EAC62",
          "userId": "UAB6926FE"
        }
      ],
      "modifiedAt": new Date('2023-07-01T06:18:51.826001'),
      "name": "Category ND5EF8190",
      "status": 0,
      "userId": "UF22EE873"
    },
    {
      "categoryId": "CAT29B4B9F8",
      "concurrencyStamp": "CS27F20024",
      "createdAt": new Date('2023-03-08T11:33:46.041180'),
      "description": "Category description D2CC05057",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT6958E658",
          "concurrencyStamp": "CSDA273208",
          "createdAt": new Date('2023-05-15T20:07:44.664960'),
          "description": "Activity description DE093F7C2",
          "endTime": new Date('2023-03-15T05:36:48.161397'),
          "modifiedAt": new Date('2024-01-08T22:11:59.685531'),
          "name": "Activity NBE0D995F",
          "startTime": new Date('2024-01-08T21:46:01.776975'),
          "userId": "U4DA027FE"
        },
        {
          "activityId": "ACT57692F7C",
          "concurrencyStamp": "CS00726F5E",
          "createdAt": new Date('2024-01-19T22:13:25.491548'),
          "description": "Activity description D9531D0F1",
          "endTime": new Date('2023-08-26T06:26:04.454700'),
          "modifiedAt": new Date('2023-12-01T05:57:52.485297'),
          "name": "Activity N2BBC2A22",
          "startTime": new Date('2023-09-04T18:33:39.004895'),
          "userId": "UF4234A9A"
        },
        {
          "activityId": "ACT5DEBB5F6",
          "concurrencyStamp": "CSF64A1B12",
          "createdAt": new Date('2023-08-27T10:51:46.591379'),
          "description": "Activity description D14C4D33D",
          "endTime": new Date('2023-07-22T01:12:19.198578'),
          "modifiedAt": new Date('2023-07-12T11:57:56.623407'),
          "name": "Activity N3C512562",
          "startTime": new Date('2023-04-06T12:32:39.987134'),
          "userId": "UC3DC3CB8"
        },
        {
          "activityId": "ACTA93418E3",
          "concurrencyStamp": "CS72A1B5DB",
          "createdAt": new Date('2023-09-05T22:07:24.149377'),
          "description": "Activity description D0CCE2308",
          "endTime": new Date('2023-02-20T00:54:34.167070'),
          "modifiedAt": new Date('2023-11-14T11:07:53.631703'),
          "name": "Activity N4D7EEA8A",
          "startTime": new Date('2023-05-02T12:30:03.052304'),
          "userId": "U24D784BD"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT843640C5",
              "concurrencyStamp": "CSB41D2E7E",
              "createdAt": new Date('2023-08-16T09:36:23.166492'),
              "description": "Activity description DCC7D1112",
              "endTime": new Date('2023-02-04T17:05:18.225320'),
              "modifiedAt": new Date('2023-10-28T19:49:16.981887'),
              "name": "Activity NED5216B1",
              "startTime": new Date('2023-12-02T18:23:23.468908'),
              "userId": "U3B1E6F8A"
            },
            {
              "activityId": "ACT2C328F10",
              "concurrencyStamp": "CSFD3B7AD7",
              "createdAt": new Date('2023-07-18T05:26:01.619897'),
              "description": "Activity description D014500D4",
              "endTime": new Date('2023-08-01T18:53:31.609020'),
              "modifiedAt": new Date('2023-12-10T00:06:07.090713'),
              "name": "Activity N5BA58A15",
              "startTime": new Date('2023-09-20T20:25:35.936891'),
              "userId": "U74E40BB5"
            }
          ],
          "concurrencyStamp": "CS319828AE",
          "createdAt": new Date('2023-06-12T15:24:05.072925'),
          "description": "Job description DBC08FCCB",
          "isExpanded": false,
          "jobId": "JOBCBFED675",
          "modifiedAt": new Date('2023-12-22T03:28:56.429241'),
          "name": "Job Name NB9169E93",
          "userId": "U3B7FF5E1"
        },
        {
          "activities": [
            {
              "activityId": "ACTB88F2E04",
              "concurrencyStamp": "CSFDDE9B1D",
              "createdAt": new Date('2023-06-23T03:34:27.545427'),
              "description": "Activity description D60CAFEA9",
              "endTime": new Date('2023-09-24T01:54:36.539229'),
              "modifiedAt": new Date('2023-06-08T04:43:28.274148'),
              "name": "Activity N27607981",
              "startTime": new Date('2023-05-15T15:03:21.639320'),
              "userId": "UEE840035"
            },
            {
              "activityId": "ACT7EAC272B",
              "concurrencyStamp": "CSC9668D0E",
              "createdAt": new Date('2024-01-26T03:19:42.765183'),
              "description": "Activity description DE46306B3",
              "endTime": new Date('2023-07-23T02:46:46.938520'),
              "modifiedAt": new Date('2023-06-23T23:50:51.531421'),
              "name": "Activity N9FF1E6A5",
              "startTime": new Date('2023-06-12T15:35:30.948207'),
              "userId": "UAFC14612"
            }
          ],
          "concurrencyStamp": "CS404C755B",
          "createdAt": new Date('2023-06-02T06:58:34.182580'),
          "description": "Job description DCBB20125",
          "isExpanded": false,
          "jobId": "JOB4416C610",
          "modifiedAt": new Date('2023-12-05T01:17:11.320445'),
          "name": "Job Name NF4631FE8",
          "userId": "U31ADF450"
        },
        {
          "activities": [
            {
              "activityId": "ACTC3FC1FF7",
              "concurrencyStamp": "CS54C9D272",
              "createdAt": new Date('2023-04-04T01:05:24.997519'),
              "description": "Activity description DEA7217CF",
              "endTime": new Date('2023-09-19T10:01:34.022484'),
              "modifiedAt": new Date('2023-04-21T12:46:39.735478'),
              "name": "Activity N3FAB9FCE",
              "startTime": new Date('2023-12-16T15:16:25.341554'),
              "userId": "U276BBB3E"
            },
            {
              "activityId": "ACT1233DA6C",
              "concurrencyStamp": "CSA64010CE",
              "createdAt": new Date('2023-02-13T21:39:20.130012'),
              "description": "Activity description DFC43C198",
              "endTime": new Date('2023-02-16T03:23:15.161893'),
              "modifiedAt": new Date('2023-04-29T06:21:16.723576'),
              "name": "Activity N3A591795",
              "startTime": new Date('2023-09-18T03:58:31.795708'),
              "userId": "U7C7F447B"
            }
          ],
          "concurrencyStamp": "CS1E033294",
          "createdAt": new Date('2023-04-04T17:01:36.194912'),
          "description": "Job description D1909ABDE",
          "isExpanded": false,
          "jobId": "JOB698F27E0",
          "modifiedAt": new Date('2023-05-06T23:19:15.072939'),
          "name": "Job Name ND97C6DA5",
          "userId": "UF8C3A197"
        },
        {
          "activities": [
            {
              "activityId": "ACT565C13B6",
              "concurrencyStamp": "CS34CEEB8E",
              "createdAt": new Date('2023-04-03T03:10:50.415247'),
              "description": "Activity description DF0AC7367",
              "endTime": new Date('2023-09-16T11:51:02.469829'),
              "modifiedAt": new Date('2023-04-11T02:19:30.283910'),
              "name": "Activity N4754B363",
              "startTime": new Date('2023-06-04T04:52:22.788347'),
              "userId": "U8B15F157"
            },
            {
              "activityId": "ACTE9FF4B73",
              "concurrencyStamp": "CSFDEE00AE",
              "createdAt": new Date('2023-11-16T22:18:20.523603'),
              "description": "Activity description D3BB55F5F",
              "endTime": new Date('2023-09-18T01:53:22.432912'),
              "modifiedAt": new Date('2023-02-21T03:11:34.337561'),
              "name": "Activity N3D4F2EF0",
              "startTime": new Date('2023-09-22T23:55:11.050691'),
              "userId": "U4421A4A4"
            },
            {
              "activityId": "ACTCD4E0A72",
              "concurrencyStamp": "CS04E306A9",
              "createdAt": new Date('2023-03-23T20:54:19.223006'),
              "description": "Activity description DC5E6CD13",
              "endTime": new Date('2023-12-05T06:26:36.006611'),
              "modifiedAt": new Date('2023-03-16T05:33:12.698984'),
              "name": "Activity NA7732EBE",
              "startTime": new Date('2023-10-19T02:35:18.483218'),
              "userId": "U7C20F3B7"
            }
          ],
          "concurrencyStamp": "CS8A7A89BF",
          "createdAt": new Date('2023-07-29T11:02:04.786489'),
          "description": "Job description DCAD8C5AD",
          "isExpanded": false,
          "jobId": "JOBEA794DDE",
          "modifiedAt": new Date('2023-10-14T02:09:48.838542'),
          "name": "Job Name N880207E2",
          "userId": "UDA6A3301"
        }
      ],
      "modifiedAt": new Date('2023-11-15T16:15:29.348325'),
      "name": "Category N3323AB80",
      "status": 3,
      "userId": "UA1D1B531"
    },
    {
      "categoryId": "CATA64E9406",
      "concurrencyStamp": "CSF3849B0E",
      "createdAt": new Date('2023-12-02T06:29:55.572547'),
      "description": "Category description D8ACD47ED",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACTC23F8FE2",
          "concurrencyStamp": "CS6F14174D",
          "createdAt": new Date('2023-04-13T20:58:27.827951'),
          "description": "Activity description DD453A55B",
          "endTime": new Date('2023-02-03T13:36:54.647607'),
          "modifiedAt": new Date('2023-04-12T10:26:27.564577'),
          "name": "Activity NF8B7F0E5",
          "startTime": new Date('2023-07-24T03:46:17.600466'),
          "userId": "U1FB02882"
        },
        {
          "activityId": "ACTAF1612CE",
          "concurrencyStamp": "CS49B74ECF",
          "createdAt": new Date('2023-03-13T19:26:55.624947'),
          "description": "Activity description D1923F927",
          "endTime": new Date('2023-08-31T17:32:22.748273'),
          "modifiedAt": new Date('2023-03-12T21:03:31.331373'),
          "name": "Activity N51719567",
          "startTime": new Date('2023-03-28T11:58:50.263360'),
          "userId": "U6B851DFC"
        },
        {
          "activityId": "ACT44EF2ABF",
          "concurrencyStamp": "CS4576EFCD",
          "createdAt": new Date('2023-02-26T22:35:50.407167'),
          "description": "Activity description DFDA007AF",
          "endTime": new Date('2024-01-18T21:59:50.502103'),
          "modifiedAt": new Date('2023-09-12T00:04:04.968793'),
          "name": "Activity N1D812A59",
          "startTime": new Date('2023-04-12T13:08:04.236825'),
          "userId": "U9F0D9E07"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT1C03C5F3",
              "concurrencyStamp": "CS4F6F3994",
              "createdAt": new Date('2023-05-09T09:25:27.691504'),
              "description": "Activity description D3B6FB826",
              "endTime": new Date('2023-02-20T14:31:59.413361'),
              "modifiedAt": new Date('2023-10-19T15:37:50.897524'),
              "name": "Activity N4EE5DDF5",
              "startTime": new Date('2023-06-17T00:21:44.478377'),
              "userId": "UD664D832"
            },
            {
              "activityId": "ACTD41C0952",
              "concurrencyStamp": "CSEA5EE417",
              "createdAt": new Date('2023-03-20T07:14:36.417962'),
              "description": "Activity description DD4745446",
              "endTime": new Date('2023-05-07T02:01:13.057503'),
              "modifiedAt": new Date('2023-11-06T05:38:20.267126'),
              "name": "Activity N78B0CE26",
              "startTime": new Date('2023-10-06T13:34:39.323344'),
              "userId": "U4000C3B6"
            },
            {
              "activityId": "ACT2819551E",
              "concurrencyStamp": "CS545A491D",
              "createdAt": new Date('2023-02-06T10:42:23.990703'),
              "description": "Activity description DDDF1C98F",
              "endTime": new Date('2023-06-02T21:54:08.083821'),
              "modifiedAt": new Date('2023-05-17T11:35:18.432345'),
              "name": "Activity N83AF5B80",
              "startTime": new Date('2024-01-10T05:02:34.905309'),
              "userId": "U5FC9CF3E"
            },
            {
              "activityId": "ACT97054885",
              "concurrencyStamp": "CSC096055D",
              "createdAt": new Date('2023-03-27T14:20:14.376201'),
              "description": "Activity description D5757635A",
              "endTime": new Date('2023-05-15T11:39:02.906632'),
              "modifiedAt": new Date('2023-07-19T03:28:22.453091'),
              "name": "Activity NA23D828E",
              "startTime": new Date('2023-08-05T20:08:22.472819'),
              "userId": "UAB687FDA"
            }
          ],
          "concurrencyStamp": "CSBC3BD8BA",
          "createdAt": new Date('2024-01-05T22:50:08.034324'),
          "description": "Job description D96A2A03B",
          "isExpanded": false,
          "jobId": "JOBE7E1ABDB",
          "modifiedAt": new Date('2023-03-16T15:43:46.358976'),
          "name": "Job Name N5CDB9BD3",
          "userId": "UA8E99B79"
        },
        {
          "activities": [
            {
              "activityId": "ACT24970C50",
              "concurrencyStamp": "CSF9AAB2D7",
              "createdAt": new Date('2023-11-28T11:21:31.152846'),
              "description": "Activity description D0793A579",
              "endTime": new Date('2023-12-05T22:09:22.772127'),
              "modifiedAt": new Date('2023-08-13T13:09:21.520753'),
              "name": "Activity N3DC0BA8F",
              "startTime": new Date('2023-12-24T19:54:00.929346'),
              "userId": "UE028F892"
            },
            {
              "activityId": "ACT01880540",
              "concurrencyStamp": "CS4D690FB9",
              "createdAt": new Date('2023-02-06T04:33:58.311287'),
              "description": "Activity description D102784E5",
              "endTime": new Date('2023-10-14T19:14:38.980104'),
              "modifiedAt": new Date('2023-09-13T09:36:21.163207'),
              "name": "Activity N3BC492A7",
              "startTime": new Date('2023-11-03T17:37:57.180695'),
              "userId": "U974CD829"
            },
            {
              "activityId": "ACTC8118024",
              "concurrencyStamp": "CS05AA42F5",
              "createdAt": new Date('2023-11-06T07:50:52.398057'),
              "description": "Activity description D49D999FF",
              "endTime": new Date('2024-01-19T04:11:08.671184'),
              "modifiedAt": new Date('2023-04-01T13:40:32.900774'),
              "name": "Activity N63A842F2",
              "startTime": new Date('2023-12-30T21:27:56.180667'),
              "userId": "UA62FEFF3"
            }
          ],
          "concurrencyStamp": "CSB475C2C4",
          "createdAt": new Date('2023-08-29T07:21:49.137674'),
          "description": "Job description D24E6580B",
          "isExpanded": false,
          "jobId": "JOBA0691313",
          "modifiedAt": new Date('2023-03-15T17:04:59.460374'),
          "name": "Job Name NA2E4E388",
          "userId": "UA3AD5926"
        }
      ],
      "modifiedAt": new Date('2024-01-07T00:13:55.310764'),
      "name": "Category N128CEDF8",
      "status": 3,
      "userId": "U433B9AC0"
    },
    {
      "categoryId": "CATBED4EFC0",
      "concurrencyStamp": "CSD52A452B",
      "createdAt": new Date('2023-09-22T03:17:51.552743'),
      "description": "Category description DE37A3F93",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT56D0DDF1",
          "concurrencyStamp": "CSC1286752",
          "createdAt": new Date('2023-09-23T17:57:35.516228'),
          "description": "Activity description D3126045F",
          "endTime": new Date('2024-01-18T06:20:28.602044'),
          "modifiedAt": new Date('2023-12-31T14:15:32.907093'),
          "name": "Activity NC385CAC1",
          "startTime": new Date('2023-12-21T03:27:38.438905'),
          "userId": "UD8C5E861"
        },
        {
          "activityId": "ACTED15CFAB",
          "concurrencyStamp": "CSF4E3E594",
          "createdAt": new Date('2023-09-21T09:09:40.076708'),
          "description": "Activity description D139266B4",
          "endTime": new Date('2023-09-22T18:07:07.906986'),
          "modifiedAt": new Date('2023-12-02T17:57:15.362409'),
          "name": "Activity NE651D54A",
          "startTime": new Date('2024-01-22T07:37:43.711822'),
          "userId": "UAEA71E10"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACTFB9A85ED",
              "concurrencyStamp": "CSB75E1516",
              "createdAt": new Date('2023-07-29T18:33:01.314984'),
              "description": "Activity description D01B84A8B",
              "endTime": new Date('2023-08-25T07:06:42.178458'),
              "modifiedAt": new Date('2023-06-08T15:40:05.582341'),
              "name": "Activity N1D08E30C",
              "startTime": new Date('2023-03-30T02:57:30.838094'),
              "userId": "U87F4C055"
            },
            {
              "activityId": "ACTD1C4422A",
              "concurrencyStamp": "CSC03726EF",
              "createdAt": new Date('2023-10-14T10:59:27.138155'),
              "description": "Activity description DDEF623CE",
              "endTime": new Date('2023-12-05T18:59:51.840749'),
              "modifiedAt": new Date('2023-10-03T17:42:51.521306'),
              "name": "Activity N24C7779B",
              "startTime": new Date('2023-06-07T09:42:50.190729'),
              "userId": "U6D730647"
            },
            {
              "activityId": "ACT9C23EB5D",
              "concurrencyStamp": "CS2718795A",
              "createdAt": new Date('2023-08-07T21:25:05.213045'),
              "description": "Activity description D6731ED03",
              "endTime": new Date('2023-04-16T19:01:17.849805'),
              "modifiedAt": new Date('2023-08-22T04:59:38.533624'),
              "name": "Activity N8F3D4157",
              "startTime": new Date('2023-10-31T23:19:48.460894'),
              "userId": "U5AFB7FA0"
            },
            {
              "activityId": "ACT0C473075",
              "concurrencyStamp": "CS5CF0D2FA",
              "createdAt": new Date('2023-10-11T03:56:03.593765'),
              "description": "Activity description D09D7089A",
              "endTime": new Date('2023-04-14T09:16:47.801514'),
              "modifiedAt": new Date('2023-01-28T12:02:22.611516'),
              "name": "Activity N0ECF729A",
              "startTime": new Date('2023-02-06T13:16:09.432385'),
              "userId": "UEDBD50A6"
            }
          ],
          "concurrencyStamp": "CSC5707582",
          "createdAt": new Date('2023-11-27T15:47:33.458703'),
          "description": "Job description DA25D9ADE",
          "isExpanded": false,
          "jobId": "JOB52CAC828",
          "modifiedAt": new Date('2023-06-15T23:26:49.756845'),
          "name": "Job Name N9D3A33ED",
          "userId": "U5D6E07AC"
        },
        {
          "activities": [
            {
              "activityId": "ACTD656A6A4",
              "concurrencyStamp": "CSE95F132B",
              "createdAt": new Date('2023-03-20T06:33:34.830123'),
              "description": "Activity description DEF2C547D",
              "endTime": new Date('2023-08-07T05:45:54.978378'),
              "modifiedAt": new Date('2024-01-13T18:44:04.810854'),
              "name": "Activity NCA6E619D",
              "startTime": new Date('2023-03-28T05:24:52.656032'),
              "userId": "U06BA3007"
            },
            {
              "activityId": "ACT933227C0",
              "concurrencyStamp": "CSEFF5BF5D",
              "createdAt": new Date('2024-01-20T00:15:34.225056'),
              "description": "Activity description DAAD581A3",
              "endTime": new Date('2023-05-15T23:50:20.009049'),
              "modifiedAt": new Date('2023-11-23T04:24:19.950050'),
              "name": "Activity N274C8CD5",
              "startTime": new Date('2023-05-29T21:16:02.541025'),
              "userId": "UEB23CCFC"
            },
            {
              "activityId": "ACT9F12ADEF",
              "concurrencyStamp": "CS2C6A8F9C",
              "createdAt": new Date('2023-05-08T05:41:09.155155'),
              "description": "Activity description D52B7BDEE",
              "endTime": new Date('2023-02-01T14:59:23.943846'),
              "modifiedAt": new Date('2023-09-14T10:56:05.863458'),
              "name": "Activity N4150856A",
              "startTime": new Date('2023-09-19T02:34:13.519425'),
              "userId": "UF97B235F"
            },
            {
              "activityId": "ACTFFC697C8",
              "concurrencyStamp": "CS7A6C0226",
              "createdAt": new Date('2023-05-01T11:24:35.899374'),
              "description": "Activity description DBE4A9B87",
              "endTime": new Date('2023-04-24T09:11:23.843702'),
              "modifiedAt": new Date('2023-08-21T02:39:59.522591'),
              "name": "Activity N61D95AEC",
              "startTime": new Date('2023-03-06T11:50:10.868058'),
              "userId": "UE11AB377"
            },
            {
              "activityId": "ACTF446B9DF",
              "concurrencyStamp": "CS7E6A7305",
              "createdAt": new Date('2023-10-29T00:05:59.344617'),
              "description": "Activity description DDC85E5B8",
              "endTime": new Date('2023-01-29T20:24:03.938546'),
              "modifiedAt": new Date('2023-06-30T01:29:46.565028'),
              "name": "Activity N5DC2EB04",
              "startTime": new Date('2023-06-08T21:11:23.566989'),
              "userId": "U2BC9AB47"
            }
          ],
          "concurrencyStamp": "CS3F55E0C2",
          "createdAt": new Date('2023-08-20T08:23:39.173932'),
          "description": "Job description D20436B2B",
          "isExpanded": false,
          "jobId": "JOB23927DD5",
          "modifiedAt": new Date('2023-11-12T13:17:03.103238'),
          "name": "Job Name NE7B1498B",
          "userId": "U87564CF3"
        },
        {
          "activities": [
            {
              "activityId": "ACT5F7C95D5",
              "concurrencyStamp": "CSF5C33344",
              "createdAt": new Date('2023-03-30T05:19:54.909339'),
              "description": "Activity description D7EE8B04B",
              "endTime": new Date('2023-11-26T12:19:10.121130'),
              "modifiedAt": new Date('2024-01-14T17:37:40.483526'),
              "name": "Activity NEBC237E8",
              "startTime": new Date('2023-04-23T02:16:33.365217'),
              "userId": "U559954A2"
            },
            {
              "activityId": "ACTF3A0C600",
              "concurrencyStamp": "CS3E416B55",
              "createdAt": new Date('2023-07-14T07:49:55.822625'),
              "description": "Activity description D556E20FE",
              "endTime": new Date('2023-04-13T21:10:35.026243'),
              "modifiedAt": new Date('2023-03-08T04:57:10.143771'),
              "name": "Activity N450F2D88",
              "startTime": new Date('2023-09-29T05:11:52.893892'),
              "userId": "UC1065811"
            },
            {
              "activityId": "ACT2766513D",
              "concurrencyStamp": "CSD56C96CE",
              "createdAt": new Date('2023-02-15T21:48:06.140052'),
              "description": "Activity description DB9616825",
              "endTime": new Date('2023-07-12T18:28:51.446428'),
              "modifiedAt": new Date('2023-12-10T21:01:22.107205'),
              "name": "Activity NA80B20A3",
              "startTime": new Date('2023-05-11T00:19:15.291801'),
              "userId": "U8903862C"
            }
          ],
          "concurrencyStamp": "CSA8390E5B",
          "createdAt": new Date('2023-08-11T14:42:14.370335'),
          "description": "Job description D8EE12F6A",
          "isExpanded": false,
          "jobId": "JOB1CE0153D",
          "modifiedAt": new Date('2023-12-10T14:49:08.640119'),
          "name": "Job Name NDB5B0AD5",
          "userId": "U6D9F4FB9"
        },
        {
          "activities": [
            {
              "activityId": "ACT5C72594E",
              "concurrencyStamp": "CSF8A9DF42",
              "createdAt": new Date('2023-09-08T15:03:17.605913'),
              "description": "Activity description DCB6D86FF",
              "endTime": new Date('2023-04-02T10:48:09.256959'),
              "modifiedAt": new Date('2023-12-05T09:41:00.310425'),
              "name": "Activity N1E9C483B",
              "startTime": new Date('2023-09-16T04:41:32.117368'),
              "userId": "UFE8EBEAB"
            },
            {
              "activityId": "ACTE90455A0",
              "concurrencyStamp": "CS3F08082E",
              "createdAt": new Date('2023-10-16T02:31:30.328607'),
              "description": "Activity description D18B05B4C",
              "endTime": new Date('2023-11-22T03:47:24.588139'),
              "modifiedAt": new Date('2023-12-01T09:59:56.200304'),
              "name": "Activity NF8216940",
              "startTime": new Date('2023-04-21T17:31:59.599294'),
              "userId": "U05251DFF"
            }
          ],
          "concurrencyStamp": "CS1E4B04A2",
          "createdAt": new Date('2023-06-01T05:23:48.723139'),
          "description": "Job description D455F6D59",
          "isExpanded": false,
          "jobId": "JOB58442DD1",
          "modifiedAt": new Date('2023-11-25T04:04:15.832146'),
          "name": "Job Name N2F6E9452",
          "userId": "UC85CF19E"
        },
        {
          "activities": [
            {
              "activityId": "ACT8ADB4A8C",
              "concurrencyStamp": "CSB2EF71FE",
              "createdAt": new Date('2023-02-28T23:39:14.373025'),
              "description": "Activity description D8C78B2CE",
              "endTime": new Date('2023-10-09T11:28:29.576115'),
              "modifiedAt": new Date('2023-03-29T14:52:59.939881'),
              "name": "Activity N8BCA9183",
              "startTime": new Date('2023-12-02T17:47:26.248908'),
              "userId": "U8276D5F0"
            },
            {
              "activityId": "ACT44356D05",
              "concurrencyStamp": "CS286DEB61",
              "createdAt": new Date('2023-10-21T21:01:07.269954'),
              "description": "Activity description DD67ECD0E",
              "endTime": new Date('2023-11-03T16:53:03.144722'),
              "modifiedAt": new Date('2023-03-31T13:22:04.147586'),
              "name": "Activity NEC7A688F",
              "startTime": new Date('2023-08-09T04:22:45.653250'),
              "userId": "UDC11B2BB"
            },
            {
              "activityId": "ACT9854FF16",
              "concurrencyStamp": "CS5C5F5C20",
              "createdAt": new Date('2023-12-09T17:34:42.514072'),
              "description": "Activity description D6141E163",
              "endTime": new Date('2023-11-22T05:38:28.845952'),
              "modifiedAt": new Date('2023-07-24T18:48:38.721245'),
              "name": "Activity ND017F5D1",
              "startTime": new Date('2023-11-10T07:29:47.800883'),
              "userId": "U4CDA3AF3"
            },
            {
              "activityId": "ACT195F8831",
              "concurrencyStamp": "CSE5030710",
              "createdAt": new Date('2023-06-29T04:11:48.184020'),
              "description": "Activity description D8E05BF08",
              "endTime": new Date('2023-10-29T12:23:07.278715'),
              "modifiedAt": new Date('2023-06-19T12:12:09.484371'),
              "name": "Activity N8953C838",
              "startTime": new Date('2023-10-31T16:56:34.079086'),
              "userId": "UC033ABFA"
            },
            {
              "activityId": "ACT4F503A28",
              "concurrencyStamp": "CS767CFEBB",
              "createdAt": new Date('2023-12-02T14:44:38.445915'),
              "description": "Activity description D69C4AFD3",
              "endTime": new Date('2023-04-13T16:13:32.579980'),
              "modifiedAt": new Date('2023-08-12T23:28:13.387273'),
              "name": "Activity N7A1471B6",
              "startTime": new Date('2023-05-17T00:59:07.524723'),
              "userId": "UA9F5EC3E"
            }
          ],
          "concurrencyStamp": "CS430D1D51",
          "createdAt": new Date('2023-11-21T02:01:53.556648'),
          "description": "Job description D1A922B4E",
          "isExpanded": false,
          "jobId": "JOB5602505F",
          "modifiedAt": new Date('2023-08-21T18:05:40.603534'),
          "name": "Job Name N12BED716",
          "userId": "UB65BC935"
        }
      ],
      "modifiedAt": new Date('2023-06-11T22:17:40.597015'),
      "name": "Category N6EB18A6F",
      "status": 5,
      "userId": "U954ADB69"
    },
    {
      "categoryId": "CATACCB8447",
      "concurrencyStamp": "CS2419B07E",
      "createdAt": new Date('2023-11-02T17:55:59.674294'),
      "description": "Category description D9BDCF2A7",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT95E1ED5A",
          "concurrencyStamp": "CSF5449029",
          "createdAt": new Date('2023-10-19T05:39:14.862088'),
          "description": "Activity description D9EF38B8A",
          "endTime": new Date('2023-08-07T08:50:52.290040'),
          "modifiedAt": new Date('2023-05-16T23:35:48.474443'),
          "name": "Activity ND665B8C7",
          "startTime": new Date('2023-07-08T08:47:17.561235'),
          "userId": "U5EBC8D79"
        },
        {
          "activityId": "ACT10CDC152",
          "concurrencyStamp": "CS4E8C645A",
          "createdAt": new Date('2023-01-28T06:24:44.510438'),
          "description": "Activity description D3574644E",
          "endTime": new Date('2023-08-09T13:03:39.451315'),
          "modifiedAt": new Date('2023-02-16T05:05:03.182053'),
          "name": "Activity NE7D89847",
          "startTime": new Date('2023-03-29T03:35:39.608972'),
          "userId": "U1295FC34"
        },
        {
          "activityId": "ACTE6BDA477",
          "concurrencyStamp": "CS5A71ECA1",
          "createdAt": new Date('2023-12-03T02:45:17.358142'),
          "description": "Activity description DDF3FE316",
          "endTime": new Date('2023-05-24T01:09:31.219915'),
          "modifiedAt": new Date('2023-10-08T05:54:23.354351'),
          "name": "Activity ND5CEA12C",
          "startTime": new Date('2023-08-01T17:26:38.437348'),
          "userId": "U9006BE60"
        },
        {
          "activityId": "ACT80FFA579",
          "concurrencyStamp": "CSA0984527",
          "createdAt": new Date('2023-07-29T13:52:32.687695'),
          "description": "Activity description DB1DAC05E",
          "endTime": new Date('2023-04-29T21:31:13.667732'),
          "modifiedAt": new Date('2023-03-12T22:11:02.260764'),
          "name": "Activity NB4B19B83",
          "startTime": new Date('2024-01-15T17:28:13.881307'),
          "userId": "U38FF8B18"
        },
        {
          "activityId": "ACT8259573F",
          "concurrencyStamp": "CSA222A14A",
          "createdAt": new Date('2023-10-20T00:07:30.709306'),
          "description": "Activity description D91BAE6E9",
          "endTime": new Date('2023-10-19T20:55:36.384124'),
          "modifiedAt": new Date('2023-12-03T01:23:12.858734'),
          "name": "Activity NB73C28A6",
          "startTime": new Date('2023-10-27T14:15:28.811676'),
          "userId": "U1E49301E"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT36710020",
              "concurrencyStamp": "CSA7DF3225",
              "createdAt": new Date('2023-11-11T19:29:26.982905'),
              "description": "Activity description D1A1882EC",
              "endTime": new Date('2023-08-25T07:09:21.960884'),
              "modifiedAt": new Date('2023-03-28T08:54:08.540215'),
              "name": "Activity N3D0396A7",
              "startTime": new Date('2023-12-13T15:04:58.362658'),
              "userId": "U35F807EF"
            },
            {
              "activityId": "ACT55B19EE5",
              "concurrencyStamp": "CSFD1EFFF8",
              "createdAt": new Date('2023-05-21T14:49:26.407633'),
              "description": "Activity description D5D73A7DB",
              "endTime": new Date('2023-11-10T00:09:47.554254'),
              "modifiedAt": new Date('2023-08-12T00:10:57.970053'),
              "name": "Activity N1E20B473",
              "startTime": new Date('2023-07-10T05:47:17.936431'),
              "userId": "U0B426089"
            },
            {
              "activityId": "ACT07BF52AC",
              "concurrencyStamp": "CSB242D1D6",
              "createdAt": new Date('2023-09-14T10:43:57.852940'),
              "description": "Activity description DC4BB1C00",
              "endTime": new Date('2023-08-30T13:57:46.900297'),
              "modifiedAt": new Date('2024-01-15T18:25:43.656999'),
              "name": "Activity N06EF9B09",
              "startTime": new Date('2023-11-18T09:08:10.785440'),
              "userId": "U7EA772E1"
            }
          ],
          "concurrencyStamp": "CS47A817DF",
          "createdAt": new Date('2023-08-04T10:23:19.486779'),
          "description": "Job description D1553BAFF",
          "isExpanded": false,
          "jobId": "JOB259C8FAB",
          "modifiedAt": new Date('2023-10-03T11:10:06.033619'),
          "name": "Job Name N0D9877DE",
          "userId": "U32E5AB6E"
        },
        {
          "activities": [
            {
              "activityId": "ACT346E2980",
              "concurrencyStamp": "CS94A88F67",
              "createdAt": new Date('2023-10-04T13:52:15.978496'),
              "description": "Activity description DEB47FDBD",
              "endTime": new Date('2023-06-22T19:41:35.343654'),
              "modifiedAt": new Date('2023-08-19T06:27:26.454202'),
              "name": "Activity N7D4C7917",
              "startTime": new Date('2023-09-29T03:07:23.734246'),
              "userId": "UFE3495E6"
            },
            {
              "activityId": "ACT5DFBFC8E",
              "concurrencyStamp": "CS72EDCEC8",
              "createdAt": new Date('2023-02-10T17:30:56.337714'),
              "description": "Activity description DF5CE9431",
              "endTime": new Date('2023-02-27T06:30:31.415311'),
              "modifiedAt": new Date('2023-03-12T05:49:15.619868'),
              "name": "Activity NC55C1E09",
              "startTime": new Date('2023-07-26T18:52:16.209418'),
              "userId": "UBF1A1DFD"
            },
            {
              "activityId": "ACTB68F850E",
              "concurrencyStamp": "CS741B220D",
              "createdAt": new Date('2023-03-12T22:34:56.083277'),
              "description": "Activity description D84F89F0B",
              "endTime": new Date('2023-03-05T12:44:01.760839'),
              "modifiedAt": new Date('2023-12-08T23:39:54.725356'),
              "name": "Activity N628221C7",
              "startTime": new Date('2023-06-14T09:15:52.622086'),
              "userId": "UC352E02A"
            },
            {
              "activityId": "ACT92922C6B",
              "concurrencyStamp": "CSC466180A",
              "createdAt": new Date('2023-05-05T13:15:36.519573'),
              "description": "Activity description DE2C0E858",
              "endTime": new Date('2023-08-10T03:44:04.733145'),
              "modifiedAt": new Date('2023-05-29T16:36:08.396050'),
              "name": "Activity N9F343AD6",
              "startTime": new Date('2023-07-06T02:27:17.211275'),
              "userId": "UC625BC8E"
            },
            {
              "activityId": "ACTACDD6C98",
              "concurrencyStamp": "CSBC32EBD2",
              "createdAt": new Date('2023-04-19T16:09:25.689634'),
              "description": "Activity description D615C086F",
              "endTime": new Date('2023-08-16T10:09:06.493920'),
              "modifiedAt": new Date('2023-08-26T02:07:11.174448'),
              "name": "Activity N2032D9E0",
              "startTime": new Date('2023-04-02T22:38:11.985591'),
              "userId": "U3EFADCF6"
            }
          ],
          "concurrencyStamp": "CS093B0202",
          "createdAt": new Date('2024-01-04T02:11:14.550462'),
          "description": "Job description D32FDFC6B",
          "isExpanded": false,
          "jobId": "JOB49C014A3",
          "modifiedAt": new Date('2023-03-02T11:16:26.869806'),
          "name": "Job Name N617B0EE2",
          "userId": "U4B00B48C"
        }
      ],
      "modifiedAt": new Date('2023-08-17T21:09:45.402671'),
      "name": "Category N5CFCC227",
      "status": 5,
      "userId": "U213ED101"
    },
    {
      "categoryId": "CAT570993D4",
      "concurrencyStamp": "CSC62F629D",
      "createdAt": new Date('2024-01-04T07:01:20.079456'),
      "description": "Category description DF4974CD3",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACTACDFBC36",
          "concurrencyStamp": "CS10BB2552",
          "createdAt": new Date('2023-11-30T18:58:06.578504'),
          "description": "Activity description D97EF507B",
          "endTime": new Date('2023-05-05T12:01:40.250781'),
          "modifiedAt": new Date('2023-08-07T07:47:51.558217'),
          "name": "Activity NB831C3C0",
          "startTime": new Date('2023-11-13T04:28:40.055922'),
          "userId": "U25B12693"
        },
        {
          "activityId": "ACT4549C753",
          "concurrencyStamp": "CSCB228A04",
          "createdAt": new Date('2023-03-28T10:02:10.287084'),
          "description": "Activity description D14AF3AAC",
          "endTime": new Date('2024-01-19T08:11:02.786649'),
          "modifiedAt": new Date('2023-12-10T07:04:50.151481'),
          "name": "Activity N11A195E9",
          "startTime": new Date('2023-08-10T18:08:11.250202'),
          "userId": "U2D46E805"
        },
        {
          "activityId": "ACTD206E95E",
          "concurrencyStamp": "CSEC77BCEA",
          "createdAt": new Date('2023-12-12T07:07:59.001900'),
          "description": "Activity description D195FA1E9",
          "endTime": new Date('2023-07-26T17:06:19.920926'),
          "modifiedAt": new Date('2023-11-25T05:32:58.163042'),
          "name": "Activity N54F7B0E6",
          "startTime": new Date('2023-04-30T09:37:38.225773'),
          "userId": "U7B98A8BF"
        },
        {
          "activityId": "ACT855D2B5B",
          "concurrencyStamp": "CS944CD61D",
          "createdAt": new Date('2023-08-26T07:32:50.695264'),
          "description": "Activity description DA9BABF2F",
          "endTime": new Date('2023-03-10T07:34:45.972948'),
          "modifiedAt": new Date('2023-09-11T06:29:19.092413'),
          "name": "Activity N83A21180",
          "startTime": new Date('2023-05-06T23:47:17.008403'),
          "userId": "UBEE1BFD3"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT5A81A3C2",
              "concurrencyStamp": "CS2AB319BD",
              "createdAt": new Date('2023-03-04T00:38:04.407474'),
              "description": "Activity description DEB1B49E6",
              "endTime": new Date('2023-09-16T02:10:25.257217'),
              "modifiedAt": new Date('2024-01-26T01:18:27.708107'),
              "name": "Activity N1875BE89",
              "startTime": new Date('2023-03-16T08:20:04.722932'),
              "userId": "UF9175BFD"
            },
            {
              "activityId": "ACT868C1D3F",
              "concurrencyStamp": "CS35AC4E66",
              "createdAt": new Date('2023-12-24T13:42:38.393609'),
              "description": "Activity description D4C5F6F52",
              "endTime": new Date('2023-02-14T13:06:45.246846'),
              "modifiedAt": new Date('2023-06-03T16:08:36.972623'),
              "name": "Activity N3603A131",
              "startTime": new Date('2023-05-12T02:28:30.007219'),
              "userId": "UE007729B"
            },
            {
              "activityId": "ACT72270C05",
              "concurrencyStamp": "CSE56F7688",
              "createdAt": new Date('2023-05-10T11:49:51.743719'),
              "description": "Activity description DFC76C95A",
              "endTime": new Date('2023-08-31T22:06:41.450044'),
              "modifiedAt": new Date('2023-02-06T12:46:40.630236'),
              "name": "Activity N5BABD94B",
              "startTime": new Date('2023-07-04T01:40:52.003559'),
              "userId": "U856B677F"
            }
          ],
          "concurrencyStamp": "CS0CCE0CD1",
          "createdAt": new Date('2023-10-20T15:34:50.742462'),
          "description": "Job description DD29A6F15",
          "isExpanded": false,
          "jobId": "JOB429B5B5C",
          "modifiedAt": new Date('2023-08-06T08:42:38.201591'),
          "name": "Job Name N305A13F9",
          "userId": "UBDAA89C3"
        },
        {
          "activities": [
            {
              "activityId": "ACT9CDB7BBD",
              "concurrencyStamp": "CS78F54E81",
              "createdAt": new Date('2023-08-28T15:49:00.443702'),
              "description": "Activity description D64AAAA38",
              "endTime": new Date('2024-01-24T23:23:54.171381'),
              "modifiedAt": new Date('2023-05-10T03:21:43.999863'),
              "name": "Activity N30FA1A8B",
              "startTime": new Date('2023-09-12T20:54:49.020795'),
              "userId": "U61DF9424"
            },
            {
              "activityId": "ACTF2C33330",
              "concurrencyStamp": "CSB6AD80ED",
              "createdAt": new Date('2023-12-28T11:02:53.412759'),
              "description": "Activity description D5F76D8D3",
              "endTime": new Date('2023-06-29T10:42:14.632505'),
              "modifiedAt": new Date('2023-02-25T22:21:24.869317'),
              "name": "Activity N0E12D03D",
              "startTime": new Date('2023-06-16T22:04:01.567520'),
              "userId": "U449722E5"
            },
            {
              "activityId": "ACT62BE1FD0",
              "concurrencyStamp": "CSBDDBEF81",
              "createdAt": new Date('2023-03-10T09:30:44.862377'),
              "description": "Activity description DF124514D",
              "endTime": new Date('2023-06-09T09:55:08.375814'),
              "modifiedAt": new Date('2023-08-13T20:55:55.309160'),
              "name": "Activity N764C4306",
              "startTime": new Date('2023-08-28T22:02:20.406659'),
              "userId": "U0D051912"
            },
            {
              "activityId": "ACTC1A54248",
              "concurrencyStamp": "CS099891B9",
              "createdAt": new Date('2023-07-06T06:34:38.861547'),
              "description": "Activity description D30982315",
              "endTime": new Date('2023-11-07T12:29:50.998123'),
              "modifiedAt": new Date('2023-10-14T22:46:43.359005'),
              "name": "Activity NFB66BA2F",
              "startTime": new Date('2023-08-14T07:11:22.415924'),
              "userId": "UA5E958C9"
            }
          ],
          "concurrencyStamp": "CSF6591247",
          "createdAt": new Date('2023-06-01T06:17:16.982302'),
          "description": "Job description D8350D2C4",
          "isExpanded": false,
          "jobId": "JOB62AC21A1",
          "modifiedAt": new Date('2023-12-29T21:30:34.236035'),
          "name": "Job Name NFFDE6C55",
          "userId": "U2318DBCA"
        },
        {
          "activities": [
            {
              "activityId": "ACT2FD0A9B6",
              "concurrencyStamp": "CSD734EC8B",
              "createdAt": new Date('2023-09-22T04:07:00.979712'),
              "description": "Activity description DF406D89A",
              "endTime": new Date('2023-12-02T10:28:20.668462'),
              "modifiedAt": new Date('2023-02-05T07:27:22.162421'),
              "name": "Activity N67744C57",
              "startTime": new Date('2023-05-27T20:33:16.657691'),
              "userId": "UF918209C"
            },
            {
              "activityId": "ACTE7673051",
              "concurrencyStamp": "CS16800794",
              "createdAt": new Date('2023-06-22T22:38:01.107208'),
              "description": "Activity description DCF38C067",
              "endTime": new Date('2023-06-05T17:05:41.292029'),
              "modifiedAt": new Date('2023-09-17T22:36:51.917966'),
              "name": "Activity N6514C43B",
              "startTime": new Date('2023-10-21T07:58:52.676874'),
              "userId": "U48459281"
            },
            {
              "activityId": "ACT1C211021",
              "concurrencyStamp": "CSABE4A31B",
              "createdAt": new Date('2023-11-19T23:00:42.226005'),
              "description": "Activity description D47A6E06D",
              "endTime": new Date('2023-12-17T14:58:28.534234'),
              "modifiedAt": new Date('2023-03-04T13:02:26.460018'),
              "name": "Activity N9A380151",
              "startTime": new Date('2023-09-19T14:47:41.051079'),
              "userId": "U6DD139FE"
            },
            {
              "activityId": "ACT793BB7F8",
              "concurrencyStamp": "CS36C523F8",
              "createdAt": new Date('2023-03-02T17:31:55.415347'),
              "description": "Activity description DCB27E4D4",
              "endTime": new Date('2023-05-24T08:28:08.780656'),
              "modifiedAt": new Date('2023-09-30T16:07:37.366522'),
              "name": "Activity N3FBB5961",
              "startTime": new Date('2023-10-03T14:01:40.262226'),
              "userId": "U789A0968"
            },
            {
              "activityId": "ACT19EEE548",
              "concurrencyStamp": "CS236E5761",
              "createdAt": new Date('2023-02-03T11:35:30.410439'),
              "description": "Activity description D54E386B7",
              "endTime": new Date('2023-11-13T23:56:15.230201'),
              "modifiedAt": new Date('2023-12-02T04:26:38.806829'),
              "name": "Activity NFF1DAC6A",
              "startTime": new Date('2023-02-28T19:22:18.539571'),
              "userId": "U21B7E80D"
            }
          ],
          "concurrencyStamp": "CS12307E6D",
          "createdAt": new Date('2023-08-06T15:50:41.937302'),
          "description": "Job description D8EEA4A92",
          "isExpanded": false,
          "jobId": "JOBCFED394F",
          "modifiedAt": new Date('2024-01-02T08:10:19.162555'),
          "name": "Job Name N16C6FB3C",
          "userId": "UD17A80DE"
        },
        {
          "activities": [
            {
              "activityId": "ACT3FB026B9",
              "concurrencyStamp": "CSDC4F43AE",
              "createdAt": new Date('2023-11-20T13:51:22.963462'),
              "description": "Activity description D460B2AAD",
              "endTime": new Date('2023-12-09T17:32:23.667622'),
              "modifiedAt": new Date('2023-11-21T05:08:14.496434'),
              "name": "Activity NF860159C",
              "startTime": new Date('2023-01-30T01:15:48.193654'),
              "userId": "U79A306D4"
            },
            {
              "activityId": "ACT2D2DC0DA",
              "concurrencyStamp": "CS458797B5",
              "createdAt": new Date('2023-10-07T06:20:15.830281'),
              "description": "Activity description D7B3DF7EA",
              "endTime": new Date('2024-01-20T10:51:44.857210'),
              "modifiedAt": new Date('2023-03-29T10:20:44.794316'),
              "name": "Activity NCD97418F",
              "startTime": new Date('2023-02-15T09:27:45.876856'),
              "userId": "UCE6603E5"
            }
          ],
          "concurrencyStamp": "CS5C2BC88D",
          "createdAt": new Date('2023-09-06T14:34:11.441103'),
          "description": "Job description D3A74EDE7",
          "isExpanded": false,
          "jobId": "JOB140E6CD7",
          "modifiedAt": new Date('2023-07-12T11:03:32.561993'),
          "name": "Job Name N0F183842",
          "userId": "U33F0CCD8"
        }
      ],
      "modifiedAt": new Date('2023-02-27T04:47:27.578022'),
      "name": "Category N73EE38DA",
      "status": 4,
      "userId": "UF72A0BA3"
    },
    {
      "categoryId": "CATF1C58BE0",
      "concurrencyStamp": "CSAD4EDE87",
      "createdAt": new Date('2023-02-10T16:35:29.639662'),
      "description": "Category description D3F917CC8",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT8553AF4D",
          "concurrencyStamp": "CS8E9F777B",
          "createdAt": new Date('2023-04-30T17:53:00.140078'),
          "description": "Activity description D5C1076F3",
          "endTime": new Date('2023-07-21T21:28:36.022059'),
          "modifiedAt": new Date('2023-05-06T08:40:05.131775'),
          "name": "Activity NC966E219",
          "startTime": new Date('2023-06-10T21:22:58.384192'),
          "userId": "UE6021DC3"
        },
        {
          "activityId": "ACT92ADE33C",
          "concurrencyStamp": "CS78B5A0C0",
          "createdAt": new Date('2023-12-17T17:02:30.376764'),
          "description": "Activity description D765A3D84",
          "endTime": new Date('2023-04-06T16:03:56.089283'),
          "modifiedAt": new Date('2023-11-13T08:19:14.343262'),
          "name": "Activity N48AC82C8",
          "startTime": new Date('2023-11-23T10:44:59.506052'),
          "userId": "UAD769854"
        },
        {
          "activityId": "ACT10A55BDB",
          "concurrencyStamp": "CS48AD247F",
          "createdAt": new Date('2023-07-27T10:01:25.952414'),
          "description": "Activity description DD35C9438",
          "endTime": new Date('2023-02-19T07:10:04.766529'),
          "modifiedAt": new Date('2023-06-08T06:30:00.405883'),
          "name": "Activity NFCF43EFD",
          "startTime": new Date('2023-03-14T00:16:44.346085'),
          "userId": "U1E64F900"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACTCCB66639",
              "concurrencyStamp": "CSE6B17FC1",
              "createdAt": new Date('2023-06-16T19:32:15.020314'),
              "description": "Activity description DCA07EF7F",
              "endTime": new Date('2023-12-20T15:04:57.776636'),
              "modifiedAt": new Date('2023-12-25T11:12:33.972669'),
              "name": "Activity N1F3244B8",
              "startTime": new Date('2023-06-21T08:16:06.394322'),
              "userId": "UEADED31F"
            },
            {
              "activityId": "ACT501314FF",
              "concurrencyStamp": "CS34944020",
              "createdAt": new Date('2023-08-18T05:26:51.479340'),
              "description": "Activity description DCDADFB96",
              "endTime": new Date('2023-10-01T11:37:18.278752'),
              "modifiedAt": new Date('2023-02-04T07:36:57.706148'),
              "name": "Activity N705668F2",
              "startTime": new Date('2023-11-22T17:55:38.804429'),
              "userId": "U1EA2F7C5"
            },
            {
              "activityId": "ACTE2954D24",
              "concurrencyStamp": "CS3F4CB1B4",
              "createdAt": new Date('2023-03-18T23:07:10.692520'),
              "description": "Activity description DC6FB2C8D",
              "endTime": new Date('2023-07-08T13:29:09.298223'),
              "modifiedAt": new Date('2023-11-28T23:07:46.775521'),
              "name": "Activity N355FA7A8",
              "startTime": new Date('2023-12-27T07:14:18.779969'),
              "userId": "U1A87CD2B"
            },
            {
              "activityId": "ACTB97398F1",
              "concurrencyStamp": "CS16D8FFB8",
              "createdAt": new Date('2023-02-09T23:33:06.646883'),
              "description": "Activity description D9B7CF800",
              "endTime": new Date('2023-12-02T00:26:22.848530'),
              "modifiedAt": new Date('2023-12-15T12:40:32.636503'),
              "name": "Activity N9995CFD3",
              "startTime": new Date('2023-04-12T06:01:48.002546'),
              "userId": "U272DF189"
            },
            {
              "activityId": "ACTB0B0DEDF",
              "concurrencyStamp": "CS2602D562",
              "createdAt": new Date('2023-07-10T08:04:42.356275'),
              "description": "Activity description D1D82F91A",
              "endTime": new Date('2023-11-24T18:19:51.887139'),
              "modifiedAt": new Date('2023-06-19T08:07:50.290294'),
              "name": "Activity NDB91D1EC",
              "startTime": new Date('2023-11-02T15:49:41.983054'),
              "userId": "UB12793C3"
            }
          ],
          "concurrencyStamp": "CS9D3B53E9",
          "createdAt": new Date('2023-09-10T01:53:59.802806'),
          "description": "Job description D1BE62A73",
          "isExpanded": false,
          "jobId": "JOB31D22D1C",
          "modifiedAt": new Date('2023-07-11T02:44:11.537571'),
          "name": "Job Name NAEF76DC3",
          "userId": "UDF158F30"
        },
        {
          "activities": [
            {
              "activityId": "ACT7E60B509",
              "concurrencyStamp": "CS8772D45D",
              "createdAt": new Date('2023-03-24T20:39:41.315380'),
              "description": "Activity description DEA7AC8FC",
              "endTime": new Date('2023-07-08T19:07:25.587451'),
              "modifiedAt": new Date('2023-09-17T17:24:07.874064'),
              "name": "Activity N95AB765F",
              "startTime": new Date('2023-09-08T04:33:24.252345'),
              "userId": "UD5375E00"
            },
            {
              "activityId": "ACT6BDAE444",
              "concurrencyStamp": "CS5320B0F8",
              "createdAt": new Date('2023-02-23T04:07:45.331812'),
              "description": "Activity description D7CA0EA0B",
              "endTime": new Date('2023-04-24T12:32:47.336738'),
              "modifiedAt": new Date('2023-10-20T01:38:30.004766'),
              "name": "Activity NEC8F0AB2",
              "startTime": new Date('2023-06-08T01:31:47.603763'),
              "userId": "U58775329"
            },
            {
              "activityId": "ACTCF032CCD",
              "concurrencyStamp": "CS84D5CCE3",
              "createdAt": new Date('2024-01-02T17:48:53.979432'),
              "description": "Activity description DA05D9E59",
              "endTime": new Date('2023-04-26T22:22:27.819643'),
              "modifiedAt": new Date('2023-06-20T09:57:51.414578'),
              "name": "Activity NC635E11C",
              "startTime": new Date('2023-06-15T21:17:48.721209'),
              "userId": "UDE0707ED"
            }
          ],
          "concurrencyStamp": "CS4BB4FF59",
          "createdAt": new Date('2023-05-06T17:24:08.397359'),
          "description": "Job description D58B39BBB",
          "isExpanded": false,
          "jobId": "JOBC5E4E2EC",
          "modifiedAt": new Date('2023-11-12T15:41:31.379950'),
          "name": "Job Name NEE441896",
          "userId": "U8A12AA32"
        }
      ],
      "modifiedAt": new Date('2023-09-12T04:54:49.106493'),
      "name": "Category N10A1074A",
      "status": 1,
      "userId": "U72C38AED"
    },
    {
      "categoryId": "CAT05C45D4F",
      "concurrencyStamp": "CSE0C49C34",
      "createdAt": new Date('2023-06-19T11:52:58.644171'),
      "description": "Category description D2D13A70C",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT8A8D1AFA",
          "concurrencyStamp": "CS414DDAC9",
          "createdAt": new Date('2023-11-04T10:13:21.474506'),
          "description": "Activity description D9D38C820",
          "endTime": new Date('2023-12-29T23:25:50.766960'),
          "modifiedAt": new Date('2023-06-03T08:22:59.670424'),
          "name": "Activity N9AB61C7D",
          "startTime": new Date('2023-12-03T09:06:58.325610'),
          "userId": "U167F5297"
        },
        {
          "activityId": "ACT6466C974",
          "concurrencyStamp": "CSB55DDC23",
          "createdAt": new Date('2023-02-18T14:58:43.458388'),
          "description": "Activity description D9E887B22",
          "endTime": new Date('2023-02-19T08:47:57.828801'),
          "modifiedAt": new Date('2023-02-06T04:13:48.795373'),
          "name": "Activity N75E9BC4C",
          "startTime": new Date('2023-11-24T17:16:12.344781'),
          "userId": "U389A9BAA"
        },
        {
          "activityId": "ACTD09E2A5B",
          "concurrencyStamp": "CS860253A2",
          "createdAt": new Date('2023-12-10T22:49:34.443450'),
          "description": "Activity description D54EC3737",
          "endTime": new Date('2023-04-25T23:45:51.721407'),
          "modifiedAt": new Date('2023-05-31T09:12:12.982864'),
          "name": "Activity N0A7C3AE1",
          "startTime": new Date('2023-06-09T19:12:24.670380'),
          "userId": "U43C1D4DC"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT5CF27D12",
              "concurrencyStamp": "CS535220AE",
              "createdAt": new Date('2023-06-13T22:52:42.651227'),
              "description": "Activity description DD3938885",
              "endTime": new Date('2023-02-21T05:25:08.138453'),
              "modifiedAt": new Date('2024-01-06T21:39:09.299938'),
              "name": "Activity NE4E872DB",
              "startTime": new Date('2023-03-12T23:35:44.172921'),
              "userId": "UBE4919FC"
            },
            {
              "activityId": "ACTC8A24F14",
              "concurrencyStamp": "CS30044607",
              "createdAt": new Date('2023-08-06T01:50:58.481504'),
              "description": "Activity description D273A3BC2",
              "endTime": new Date('2024-01-12T12:00:23.255687'),
              "modifiedAt": new Date('2023-10-25T19:44:49.152684'),
              "name": "Activity N4756BFA7",
              "startTime": new Date('2023-11-30T04:49:05.287549'),
              "userId": "U00B12715"
            },
            {
              "activityId": "ACT8FAE5250",
              "concurrencyStamp": "CS9BDEB26A",
              "createdAt": new Date('2023-11-02T00:12:23.908577'),
              "description": "Activity description DDD5352D1",
              "endTime": new Date('2023-09-01T07:14:19.138332'),
              "modifiedAt": new Date('2023-07-15T08:21:12.489893'),
              "name": "Activity NA915EF77",
              "startTime": new Date('2023-09-12T21:39:25.973573'),
              "userId": "U404B0948"
            },
            {
              "activityId": "ACT4D3552EA",
              "concurrencyStamp": "CS89564D68",
              "createdAt": new Date('2023-06-16T11:37:58.858566'),
              "description": "Activity description DFA5273A0",
              "endTime": new Date('2023-04-29T20:41:25.058856'),
              "modifiedAt": new Date('2023-09-17T04:27:39.704062'),
              "name": "Activity N58156903",
              "startTime": new Date('2023-11-06T15:25:25.112011'),
              "userId": "U3ED985E5"
            }
          ],
          "concurrencyStamp": "CS01EC0D25",
          "createdAt": new Date('2023-06-16T23:38:59.084730'),
          "description": "Job description D5D0DA2DC",
          "isExpanded": false,
          "jobId": "JOBDE5B20C5",
          "modifiedAt": new Date('2023-05-24T19:26:58.243499'),
          "name": "Job Name N9B261F6A",
          "userId": "U6A3589A2"
        },
        {
          "activities": [
            {
              "activityId": "ACT99A8D3C0",
              "concurrencyStamp": "CSBEB4CF73",
              "createdAt": new Date('2023-11-21T09:34:55.794699'),
              "description": "Activity description D7A8DBA35",
              "endTime": new Date('2023-10-14T14:20:00.074753'),
              "modifiedAt": new Date('2023-07-23T14:28:10.276006'),
              "name": "Activity N1332F19F",
              "startTime": new Date('2023-01-29T22:06:57.810165'),
              "userId": "U5D4831FB"
            },
            {
              "activityId": "ACTAF42213B",
              "concurrencyStamp": "CSF0F21FCE",
              "createdAt": new Date('2023-05-18T21:59:13.570974'),
              "description": "Activity description D99C5C2C3",
              "endTime": new Date('2024-01-26T05:18:13.847161'),
              "modifiedAt": new Date('2023-04-25T12:04:49.319981'),
              "name": "Activity N90EAC1E0",
              "startTime": new Date('2023-09-20T02:23:27.521805'),
              "userId": "UB51D95DA"
            },
            {
              "activityId": "ACT4E751FD3",
              "concurrencyStamp": "CS1500F03A",
              "createdAt": new Date('2023-04-23T06:56:15.226998'),
              "description": "Activity description D5532B259",
              "endTime": new Date('2023-11-10T05:55:09.555550'),
              "modifiedAt": new Date('2023-06-20T06:29:53.114576'),
              "name": "Activity NEAD647A5",
              "startTime": new Date('2023-05-26T03:24:42.160466'),
              "userId": "UA6536A98"
            },
            {
              "activityId": "ACTC0764B7D",
              "concurrencyStamp": "CS1CA37CBF",
              "createdAt": new Date('2024-01-11T12:39:10.704562'),
              "description": "Activity description DEF90B9D3",
              "endTime": new Date('2023-08-28T02:17:39.138460'),
              "modifiedAt": new Date('2023-12-06T11:02:43.186043'),
              "name": "Activity N2379FE26",
              "startTime": new Date('2023-07-02T02:07:17.406682'),
              "userId": "UC4DB1916"
            },
            {
              "activityId": "ACT6A9B987B",
              "concurrencyStamp": "CS33873A42",
              "createdAt": new Date('2023-03-07T22:55:03.565481'),
              "description": "Activity description D19E2ED97",
              "endTime": new Date('2023-05-11T05:58:43.446162'),
              "modifiedAt": new Date('2023-04-07T19:52:34.517613'),
              "name": "Activity N7FEB564E",
              "startTime": new Date('2023-04-25T03:15:43.004159'),
              "userId": "U83CF04F2"
            }
          ],
          "concurrencyStamp": "CS6FDAD2CE",
          "createdAt": new Date('2023-09-10T01:42:23.013751'),
          "description": "Job description D58C9F567",
          "isExpanded": false,
          "jobId": "JOB544B11A8",
          "modifiedAt": new Date('2023-05-16T15:21:55.747000'),
          "name": "Job Name NAE872FDA",
          "userId": "U58A84D28"
        },
        {
          "activities": [
            {
              "activityId": "ACTD106FEF9",
              "concurrencyStamp": "CS62E4714B",
              "createdAt": new Date('2023-07-17T02:28:09.283057'),
              "description": "Activity description D606A1739",
              "endTime": new Date('2023-05-15T23:07:47.360992'),
              "modifiedAt": new Date('2023-04-08T23:59:27.587774'),
              "name": "Activity N21F4C850",
              "startTime": new Date('2023-07-01T06:36:20.828075'),
              "userId": "U8591D153"
            },
            {
              "activityId": "ACT59C8DC87",
              "concurrencyStamp": "CSCEE5F720",
              "createdAt": new Date('2023-06-02T08:27:51.384185'),
              "description": "Activity description DBFE0EE94",
              "endTime": new Date('2023-02-23T02:44:44.641782'),
              "modifiedAt": new Date('2023-09-11T10:45:31.811666'),
              "name": "Activity N81D011BC",
              "startTime": new Date('2023-06-30T13:25:58.754749'),
              "userId": "UC601AF7D"
            },
            {
              "activityId": "ACT120BC729",
              "concurrencyStamp": "CS7C7D835D",
              "createdAt": new Date('2023-07-18T15:51:02.425927'),
              "description": "Activity description D6912F1D8",
              "endTime": new Date('2023-04-20T03:48:54.627724'),
              "modifiedAt": new Date('2023-12-19T20:52:38.701295'),
              "name": "Activity N7EB0889E",
              "startTime": new Date('2023-12-22T15:47:10.073487'),
              "userId": "UD88E8F9B"
            },
            {
              "activityId": "ACT72F130F9",
              "concurrencyStamp": "CSDB3A20C2",
              "createdAt": new Date('2023-08-02T22:34:28.566700'),
              "description": "Activity description DE2CD59CE",
              "endTime": new Date('2023-06-21T15:06:10.343293'),
              "modifiedAt": new Date('2023-07-13T00:56:34.680133'),
              "name": "Activity NA5F31381",
              "startTime": new Date('2023-07-03T18:30:13.893663'),
              "userId": "U4A95DCD9"
            }
          ],
          "concurrencyStamp": "CS07C92CCA",
          "createdAt": new Date('2023-08-04T11:59:03.808950'),
          "description": "Job description D762D2A5C",
          "isExpanded": false,
          "jobId": "JOBB05DFA95",
          "modifiedAt": new Date('2023-07-02T05:36:09.419161'),
          "name": "Job Name NEC1645CC",
          "userId": "U87114CE9"
        }
      ],
      "modifiedAt": new Date('2023-04-30T08:15:30.024509'),
      "name": "Category N01D89DAA",
      "status": 3,
      "userId": "UD882CB3F"
    },
    {
      "categoryId": "CAT15AC983A",
      "concurrencyStamp": "CSBE8AC0AC",
      "createdAt": new Date('2023-04-21T16:07:40.540137'),
      "description": "Category description D3257DB86",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT53947EA3",
          "concurrencyStamp": "CS3A8FB5D4",
          "createdAt": new Date('2023-04-09T18:25:28.458282'),
          "description": "Activity description D3FE6761F",
          "endTime": new Date('2023-03-27T16:29:04.866146'),
          "modifiedAt": new Date('2023-08-10T20:51:40.011333'),
          "name": "Activity N81B98A85",
          "startTime": new Date('2023-11-17T11:28:44.040112'),
          "userId": "UEEA27554"
        },
        {
          "activityId": "ACT7491CE27",
          "concurrencyStamp": "CS7D57338A",
          "createdAt": new Date('2023-07-22T05:56:49.383083'),
          "description": "Activity description D91EC1B28",
          "endTime": new Date('2023-03-01T10:51:08.247783'),
          "modifiedAt": new Date('2023-03-02T00:03:39.483595'),
          "name": "Activity N2013AFAA",
          "startTime": new Date('2023-09-25T23:51:13.590798'),
          "userId": "U11D2791F"
        },
        {
          "activityId": "ACT513EFF96",
          "concurrencyStamp": "CS67585015",
          "createdAt": new Date('2023-02-10T11:22:13.918260'),
          "description": "Activity description DB0091C9C",
          "endTime": new Date('2023-10-31T12:00:26.851886'),
          "modifiedAt": new Date('2023-09-21T03:35:45.531611'),
          "name": "Activity N7B9D443C",
          "startTime": new Date('2023-07-08T12:14:23.061068'),
          "userId": "U292B551C"
        },
        {
          "activityId": "ACTCF0E2FC6",
          "concurrencyStamp": "CS31427F5F",
          "createdAt": new Date('2023-09-18T07:14:59.288040'),
          "description": "Activity description D1110F316",
          "endTime": new Date('2023-02-07T16:39:28.090261'),
          "modifiedAt": new Date('2023-10-13T00:48:05.659119'),
          "name": "Activity N55E0FB1E",
          "startTime": new Date('2023-09-02T19:33:53.995100'),
          "userId": "UBA07B20F"
        },
        {
          "activityId": "ACTC4C5BD81",
          "concurrencyStamp": "CS46804FBC",
          "createdAt": new Date('2023-12-16T07:18:21.365389'),
          "description": "Activity description D1264A5D5",
          "endTime": new Date('2024-01-11T00:17:50.996981'),
          "modifiedAt": new Date('2023-10-26T17:08:28.679872'),
          "name": "Activity N3C11FBDF",
          "startTime": new Date('2023-12-26T18:42:32.480584'),
          "userId": "U439CBC7E"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACTAF052097",
              "concurrencyStamp": "CSC84D5863",
              "createdAt": new Date('2023-05-29T03:20:14.703116'),
              "description": "Activity description D962EB6EA",
              "endTime": new Date('2023-11-21T05:33:11.441105'),
              "modifiedAt": new Date('2023-10-17T22:20:25.939305'),
              "name": "Activity NFBE0F4C9",
              "startTime": new Date('2023-11-06T01:07:29.431174'),
              "userId": "U72E7EAE9"
            },
            {
              "activityId": "ACT37B83C26",
              "concurrencyStamp": "CSE9DF166B",
              "createdAt": new Date('2023-04-11T12:24:03.318041'),
              "description": "Activity description D9727F0AB",
              "endTime": new Date('2023-11-10T23:35:55.262113'),
              "modifiedAt": new Date('2023-02-26T19:58:33.165560'),
              "name": "Activity N067C15C2",
              "startTime": new Date('2023-11-20T11:26:35.137527'),
              "userId": "UC8B50AC1"
            },
            {
              "activityId": "ACT84D68ACD",
              "concurrencyStamp": "CS3BAF408D",
              "createdAt": new Date('2023-09-26T11:05:20.988479'),
              "description": "Activity description DE56D040D",
              "endTime": new Date('2023-06-25T16:09:58.471474'),
              "modifiedAt": new Date('2023-06-29T05:57:07.957753'),
              "name": "Activity N840FDCEC",
              "startTime": new Date('2023-07-31T00:22:45.621236'),
              "userId": "U92191DEE"
            }
          ],
          "concurrencyStamp": "CS05A6521D",
          "createdAt": new Date('2023-05-22T09:06:32.191267'),
          "description": "Job description D0C6BB6E8",
          "isExpanded": false,
          "jobId": "JOBA29EC837",
          "modifiedAt": new Date('2023-07-23T05:50:10.719158'),
          "name": "Job Name NE28B0FCE",
          "userId": "U37B6775F"
        },
        {
          "activities": [
            {
              "activityId": "ACT7E827270",
              "concurrencyStamp": "CS2D68C09A",
              "createdAt": new Date('2023-12-17T00:39:59.644476'),
              "description": "Activity description DDDF16C8A",
              "endTime": new Date('2023-03-31T16:20:26.236394'),
              "modifiedAt": new Date('2023-12-21T10:41:19.167872'),
              "name": "Activity N58E6F852",
              "startTime": new Date('2023-07-20T04:25:52.233727'),
              "userId": "U3C156082"
            },
            {
              "activityId": "ACT85CECF6A",
              "concurrencyStamp": "CSA8B4CFCD",
              "createdAt": new Date('2023-12-10T02:06:29.708262'),
              "description": "Activity description D9C72CAEC",
              "endTime": new Date('2023-04-25T09:26:50.791076'),
              "modifiedAt": new Date('2023-09-24T02:32:50.316467'),
              "name": "Activity N967DC650",
              "startTime": new Date('2024-01-21T21:37:30.925897'),
              "userId": "UC4661141"
            },
            {
              "activityId": "ACT9C5AE870",
              "concurrencyStamp": "CSC2BBE37C",
              "createdAt": new Date('2023-10-03T10:51:09.886549'),
              "description": "Activity description D7C0D85F4",
              "endTime": new Date('2023-12-20T16:37:03.766265'),
              "modifiedAt": new Date('2023-12-12T12:44:22.987342'),
              "name": "Activity N9868EF90",
              "startTime": new Date('2023-08-11T09:14:23.156172'),
              "userId": "U11874F08"
            }
          ],
          "concurrencyStamp": "CS7A3C2C2A",
          "createdAt": new Date('2023-10-28T07:00:27.319732'),
          "description": "Job description DECB5D6B7",
          "isExpanded": false,
          "jobId": "JOB0A4ADFC6",
          "modifiedAt": new Date('2023-12-30T09:24:10.192949'),
          "name": "Job Name N6E3B919C",
          "userId": "UF8B156C5"
        },
        {
          "activities": [
            {
              "activityId": "ACT49BBB6AB",
              "concurrencyStamp": "CS3C51B814",
              "createdAt": new Date('2023-11-05T07:26:33.024248'),
              "description": "Activity description DE0D3A6EC",
              "endTime": new Date('2023-12-26T18:34:29.523812'),
              "modifiedAt": new Date('2023-03-12T09:01:37.457316'),
              "name": "Activity NA1824F56",
              "startTime": new Date('2023-12-07T19:04:58.785726'),
              "userId": "UDD310944"
            },
            {
              "activityId": "ACTB7543B5B",
              "concurrencyStamp": "CSE9E1AAD5",
              "createdAt": new Date('2023-09-19T18:22:45.737739'),
              "description": "Activity description D8DB0E7CE",
              "endTime": new Date('2023-09-10T01:27:37.081407'),
              "modifiedAt": new Date('2023-05-07T18:56:16.623087'),
              "name": "Activity ND091B23A",
              "startTime": new Date('2023-05-16T11:37:02.154603'),
              "userId": "U42BAE9E0"
            },
            {
              "activityId": "ACT7B17A96B",
              "concurrencyStamp": "CS396B9599",
              "createdAt": new Date('2023-07-15T15:39:59.282507'),
              "description": "Activity description DFC2CE74A",
              "endTime": new Date('2023-10-20T07:01:34.520541'),
              "modifiedAt": new Date('2023-04-02T06:28:27.973101'),
              "name": "Activity N4C904EAE",
              "startTime": new Date('2023-07-01T03:37:01.360795'),
              "userId": "UC70BB25E"
            }
          ],
          "concurrencyStamp": "CS0EAC17EB",
          "createdAt": new Date('2023-02-17T17:09:06.491508'),
          "description": "Job description D22668CFD",
          "isExpanded": false,
          "jobId": "JOB8852C693",
          "modifiedAt": new Date('2024-01-27T00:50:42.769579'),
          "name": "Job Name ND9A3E7D1",
          "userId": "UE8E54458"
        },
        {
          "activities": [
            {
              "activityId": "ACT75FECE53",
              "concurrencyStamp": "CS00325326",
              "createdAt": new Date('2023-06-13T01:29:37.365551'),
              "description": "Activity description D1BC4FD9B",
              "endTime": new Date('2023-08-23T17:16:37.983167'),
              "modifiedAt": new Date('2023-10-23T23:47:01.815696'),
              "name": "Activity N170CEC0C",
              "startTime": new Date('2023-05-16T03:26:04.322873'),
              "userId": "U8948D299"
            },
            {
              "activityId": "ACTC8A11969",
              "concurrencyStamp": "CS3957F9D5",
              "createdAt": new Date('2023-05-30T23:45:23.355025'),
              "description": "Activity description D2709EBC4",
              "endTime": new Date('2023-05-11T19:53:09.897143'),
              "modifiedAt": new Date('2023-10-30T18:35:05.763014'),
              "name": "Activity N259DB743",
              "startTime": new Date('2023-11-25T00:00:47.398978'),
              "userId": "U52DFD8FE"
            },
            {
              "activityId": "ACT494F9F86",
              "concurrencyStamp": "CS68285C5C",
              "createdAt": new Date('2023-03-29T01:25:53.696605'),
              "description": "Activity description D8E98017B",
              "endTime": new Date('2023-08-04T17:02:45.216197'),
              "modifiedAt": new Date('2023-11-30T01:18:40.368370'),
              "name": "Activity N8E84CAFF",
              "startTime": new Date('2023-06-24T19:07:28.229680'),
              "userId": "UF9236E2B"
            }
          ],
          "concurrencyStamp": "CS817F00E5",
          "createdAt": new Date('2023-09-06T11:32:55.916127'),
          "description": "Job description DB804A884",
          "isExpanded": false,
          "jobId": "JOBEEDEFA38",
          "modifiedAt": new Date('2023-06-08T21:21:18.746064'),
          "name": "Job Name N96E74767",
          "userId": "UFB929351"
        }
      ],
      "modifiedAt": new Date('2023-06-23T18:40:10.437492'),
      "name": "Category N23271A05",
      "status": 3,
      "userId": "U2147D9F1"
    },
    {
      "categoryId": "CAT88102B87",
      "concurrencyStamp": "CS2D4C0868",
      "createdAt": new Date('2023-07-28T19:14:20.964867'),
      "description": "Category description D45FF04A5",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT2782BA5B",
          "concurrencyStamp": "CSB5DD3EB3",
          "createdAt": new Date('2023-08-14T09:19:08.359058'),
          "description": "Activity description D3918B5D4",
          "endTime": new Date('2023-04-28T10:51:21.062609'),
          "modifiedAt": new Date('2023-12-10T12:10:23.747923'),
          "name": "Activity N53A3FE89",
          "startTime": new Date('2023-02-17T21:36:38.227037'),
          "userId": "U3FC0D96F"
        },
        {
          "activityId": "ACTF2F83049",
          "concurrencyStamp": "CS749E2E27",
          "createdAt": new Date('2023-10-25T01:21:36.162172'),
          "description": "Activity description D97FA1548",
          "endTime": new Date('2023-08-17T07:10:01.660134'),
          "modifiedAt": new Date('2023-07-20T02:23:49.041604'),
          "name": "Activity NE31F7084",
          "startTime": new Date('2023-09-03T01:45:12.558114'),
          "userId": "U8733B6C0"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT2397F0F4",
              "concurrencyStamp": "CS2264F9E9",
              "createdAt": new Date('2023-11-09T00:43:07.241996'),
              "description": "Activity description D7334B80C",
              "endTime": new Date('2023-02-24T07:57:30.190673'),
              "modifiedAt": new Date('2023-04-08T10:03:04.694630'),
              "name": "Activity N82B745F4",
              "startTime": new Date('2023-03-25T21:52:44.445078'),
              "userId": "U7C45C346"
            },
            {
              "activityId": "ACT4EF546A0",
              "concurrencyStamp": "CS6B6652CA",
              "createdAt": new Date('2023-03-06T21:34:07.211323'),
              "description": "Activity description D204B26F1",
              "endTime": new Date('2023-09-17T16:56:02.662861'),
              "modifiedAt": new Date('2023-06-06T15:30:24.430376'),
              "name": "Activity N4F979D67",
              "startTime": new Date('2023-03-24T22:24:56.881282'),
              "userId": "U6D7A94D5"
            },
            {
              "activityId": "ACT7ABC8AEA",
              "concurrencyStamp": "CS81EFE004",
              "createdAt": new Date('2023-10-15T19:26:53.567937'),
              "description": "Activity description DBE2D32E2",
              "endTime": new Date('2023-10-22T21:29:22.050358'),
              "modifiedAt": new Date('2023-02-13T08:25:47.975172'),
              "name": "Activity NBA03D66F",
              "startTime": new Date('2023-04-25T05:06:42.495462'),
              "userId": "UDCA8B777"
            },
            {
              "activityId": "ACTAC81DB43",
              "concurrencyStamp": "CS6FD71CB4",
              "createdAt": new Date('2023-06-24T23:04:11.521560'),
              "description": "Activity description DE47F5D35",
              "endTime": new Date('2023-03-21T18:29:38.849443'),
              "modifiedAt": new Date('2023-10-15T18:19:46.213588'),
              "name": "Activity NE7A2D6EF",
              "startTime": new Date('2023-07-30T11:48:56.123089'),
              "userId": "U93566326"
            }
          ],
          "concurrencyStamp": "CSF9B6922C",
          "createdAt": new Date('2023-12-28T14:34:32.861746'),
          "description": "Job description DF41932D7",
          "isExpanded": false,
          "jobId": "JOB000EF0FF",
          "modifiedAt": new Date('2023-09-13T05:09:28.974816'),
          "name": "Job Name N8C6B8736",
          "userId": "UB53DA3EE"
        },
        {
          "activities": [
            {
              "activityId": "ACTB5131668",
              "concurrencyStamp": "CS0CD41950",
              "createdAt": new Date('2023-02-26T22:23:09.712993'),
              "description": "Activity description D2906B7DD",
              "endTime": new Date('2023-07-31T16:36:07.903144'),
              "modifiedAt": new Date('2023-11-23T12:43:56.120663'),
              "name": "Activity N4CA95F81",
              "startTime": new Date('2023-09-25T15:31:11.129798'),
              "userId": "UBFAF3076"
            },
            {
              "activityId": "ACT0587BFCB",
              "concurrencyStamp": "CSE72BEC59",
              "createdAt": new Date('2023-03-09T10:23:02.924174'),
              "description": "Activity description DD6F66E92",
              "endTime": new Date('2023-03-01T14:59:48.693084'),
              "modifiedAt": new Date('2023-03-01T10:15:08.415471'),
              "name": "Activity N39694FE7",
              "startTime": new Date('2023-12-14T17:14:06.935149'),
              "userId": "U5BC1C5D6"
            },
            {
              "activityId": "ACTBD61217E",
              "concurrencyStamp": "CSBEFCB0A2",
              "createdAt": new Date('2023-04-14T03:44:15.269902'),
              "description": "Activity description D49677330",
              "endTime": new Date('2023-07-23T14:37:31.045768'),
              "modifiedAt": new Date('2023-12-27T21:44:37.211105'),
              "name": "Activity NBDF5E54D",
              "startTime": new Date('2023-10-06T05:01:51.694953'),
              "userId": "UED87DCA7"
            }
          ],
          "concurrencyStamp": "CS17AC9479",
          "createdAt": new Date('2023-11-14T11:26:32.446160'),
          "description": "Job description D7096BC2A",
          "isExpanded": false,
          "jobId": "JOB6BC01B1D",
          "modifiedAt": new Date('2023-03-11T22:08:59.697964'),
          "name": "Job Name ND9293269",
          "userId": "U6C97A0DE"
        },
        {
          "activities": [
            {
              "activityId": "ACTBC012811",
              "concurrencyStamp": "CS0E4F61AF",
              "createdAt": new Date('2023-06-30T00:13:07.118445'),
              "description": "Activity description D64080027",
              "endTime": new Date('2023-11-24T23:06:53.380259'),
              "modifiedAt": new Date('2023-12-04T18:30:49.115540'),
              "name": "Activity NC7D361BE",
              "startTime": new Date('2023-06-11T16:49:42.053564'),
              "userId": "U8A40C819"
            },
            {
              "activityId": "ACT7DD55580",
              "concurrencyStamp": "CSF2D46282",
              "createdAt": new Date('2023-02-20T17:34:11.998602'),
              "description": "Activity description D36CF6A6D",
              "endTime": new Date('2023-04-30T03:02:27.707089'),
              "modifiedAt": new Date('2023-05-03T06:03:23.720110'),
              "name": "Activity N9EBC2579",
              "startTime": new Date('2023-06-15T11:06:06.012093'),
              "userId": "U8A241FF2"
            }
          ],
          "concurrencyStamp": "CS37405B02",
          "createdAt": new Date('2023-12-12T16:18:41.581351'),
          "description": "Job description DB61BCDBC",
          "isExpanded": false,
          "jobId": "JOB70848994",
          "modifiedAt": new Date('2023-05-25T19:16:46.625054'),
          "name": "Job Name NDF990AE6",
          "userId": "U0DDD9A1D"
        },
        {
          "activities": [
            {
              "activityId": "ACTC5C7A5D6",
              "concurrencyStamp": "CS83E422A0",
              "createdAt": new Date('2023-09-03T19:13:52.614781'),
              "description": "Activity description D334EA571",
              "endTime": new Date('2023-04-30T18:30:37.616866'),
              "modifiedAt": new Date('2023-12-27T20:00:38.338168'),
              "name": "Activity NCFEF5310",
              "startTime": new Date('2023-02-28T18:52:20.104736'),
              "userId": "U6BBCDAFF"
            },
            {
              "activityId": "ACT0A87E7D9",
              "concurrencyStamp": "CS237DD024",
              "createdAt": new Date('2023-09-06T15:19:10.475569'),
              "description": "Activity description DFEEB176A",
              "endTime": new Date('2023-07-06T06:22:13.816923'),
              "modifiedAt": new Date('2023-11-14T03:36:18.114013'),
              "name": "Activity N591F98D1",
              "startTime": new Date('2023-11-21T18:26:20.949681'),
              "userId": "UDCC9BFCD"
            },
            {
              "activityId": "ACT66D2332D",
              "concurrencyStamp": "CS117E526D",
              "createdAt": new Date('2023-05-02T08:03:46.502460'),
              "description": "Activity description D6B10DE66",
              "endTime": new Date('2023-07-08T21:44:30.852013'),
              "modifiedAt": new Date('2024-01-26T04:13:27.825355'),
              "name": "Activity N2D2D68C9",
              "startTime": new Date('2023-02-08T23:14:57.995345'),
              "userId": "UE73F2497"
            },
            {
              "activityId": "ACT2A306BD6",
              "concurrencyStamp": "CS15A8943D",
              "createdAt": new Date('2023-07-13T12:35:34.867868'),
              "description": "Activity description D0D36EF69",
              "endTime": new Date('2023-10-29T08:39:38.078068'),
              "modifiedAt": new Date('2023-11-12T10:46:22.272299'),
              "name": "Activity N6C6396D0",
              "startTime": new Date('2023-07-30T04:11:44.429558'),
              "userId": "UB348ECFE"
            }
          ],
          "concurrencyStamp": "CSACA76E58",
          "createdAt": new Date('2023-04-14T15:19:27.213712'),
          "description": "Job description DCB8A4DFB",
          "isExpanded": false,
          "jobId": "JOB72710A72",
          "modifiedAt": new Date('2023-04-27T09:41:27.257151'),
          "name": "Job Name N1B97C40D",
          "userId": "UCF7A5063"
        },
        {
          "activities": [
            {
              "activityId": "ACT1D8F10AD",
              "concurrencyStamp": "CSA31E4CC3",
              "createdAt": new Date('2023-07-29T13:50:53.058469'),
              "description": "Activity description DDC68264B",
              "endTime": new Date('2023-09-07T16:56:39.795273'),
              "modifiedAt": new Date('2024-01-20T01:04:21.642992'),
              "name": "Activity NB1423918",
              "startTime": new Date('2023-07-14T11:16:24.184798'),
              "userId": "U64AF8B67"
            },
            {
              "activityId": "ACTD2D651EC",
              "concurrencyStamp": "CS52ADBB3C",
              "createdAt": new Date('2023-11-07T14:57:59.343081'),
              "description": "Activity description D471455CC",
              "endTime": new Date('2023-08-17T22:02:03.500703'),
              "modifiedAt": new Date('2023-10-01T05:45:56.201602'),
              "name": "Activity NBA8C80AC",
              "startTime": new Date('2024-01-21T02:37:27.538840'),
              "userId": "U850F2F7C"
            },
            {
              "activityId": "ACTC51467A7",
              "concurrencyStamp": "CS5FBEB7D4",
              "createdAt": new Date('2023-12-24T23:18:51.511222'),
              "description": "Activity description D328697DB",
              "endTime": new Date('2023-09-26T22:27:39.853191'),
              "modifiedAt": new Date('2023-08-28T03:19:59.534660'),
              "name": "Activity NC35724F4",
              "startTime": new Date('2023-02-20T04:10:39.627224'),
              "userId": "UC2B91E99"
            },
            {
              "activityId": "ACTB3CC9AB3",
              "concurrencyStamp": "CS853A726A",
              "createdAt": new Date('2024-01-25T19:53:33.300074'),
              "description": "Activity description D7095A7A4",
              "endTime": new Date('2023-08-27T00:31:56.171035'),
              "modifiedAt": new Date('2023-02-24T12:44:29.931815'),
              "name": "Activity N9A9CED9A",
              "startTime": new Date('2023-12-07T00:57:10.480604'),
              "userId": "UCA5A9184"
            }
          ],
          "concurrencyStamp": "CS63084466",
          "createdAt": new Date('2023-06-03T04:52:40.436692'),
          "description": "Job description DFB1803BD",
          "isExpanded": false,
          "jobId": "JOB73D61E40",
          "modifiedAt": new Date('2023-06-13T14:07:49.446013'),
          "name": "Job Name NA31CEF12",
          "userId": "U94F0F86E"
        }
      ],
      "modifiedAt": new Date('2023-03-25T01:45:36.259898'),
      "name": "Category NAD82358E",
      "status": 3,
      "userId": "UCEF2FBDC"
    },
    {
      "categoryId": "CATA0095AC1",
      "concurrencyStamp": "CS4A64066B",
      "createdAt": new Date('2023-04-26T15:51:32.556615'),
      "description": "Category description DE8547586",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT414C3804",
          "concurrencyStamp": "CSBF820571",
          "createdAt": new Date('2023-04-16T18:41:00.357836'),
          "description": "Activity description D05CB8DFE",
          "endTime": new Date('2023-10-02T06:25:10.348731'),
          "modifiedAt": new Date('2023-07-26T14:08:28.221411'),
          "name": "Activity N1EDA14B8",
          "startTime": new Date('2023-04-13T22:08:06.990705'),
          "userId": "UE2D86760"
        },
        {
          "activityId": "ACTE3616924",
          "concurrencyStamp": "CSCC306737",
          "createdAt": new Date('2023-08-20T21:26:51.815889'),
          "description": "Activity description DE2EB5A0C",
          "endTime": new Date('2023-11-06T04:50:22.903972'),
          "modifiedAt": new Date('2023-10-03T04:56:37.588334'),
          "name": "Activity NF963EBEF",
          "startTime": new Date('2023-10-21T05:44:16.088066'),
          "userId": "U68A195CB"
        },
        {
          "activityId": "ACT3CCC747C",
          "concurrencyStamp": "CS145DDDC3",
          "createdAt": new Date('2023-10-27T06:00:10.510834'),
          "description": "Activity description D5FCD04EB",
          "endTime": new Date('2023-12-06T07:25:22.409908'),
          "modifiedAt": new Date('2024-01-12T21:26:26.370824'),
          "name": "Activity N805B7B3B",
          "startTime": new Date('2023-08-05T11:42:06.279250'),
          "userId": "UEC062700"
        },
        {
          "activityId": "ACTB2462F47",
          "concurrencyStamp": "CSE373A0A9",
          "createdAt": new Date('2023-10-03T13:38:48.144329'),
          "description": "Activity description D41A3D96D",
          "endTime": new Date('2023-06-11T06:04:46.385463'),
          "modifiedAt": new Date('2023-05-30T13:56:05.025913'),
          "name": "Activity N33F081C4",
          "startTime": new Date('2023-02-25T20:23:05.173118'),
          "userId": "U0B79CABB"
        },
        {
          "activityId": "ACTEAB9B2E8",
          "concurrencyStamp": "CS198646F1",
          "createdAt": new Date('2024-01-14T03:02:20.794626'),
          "description": "Activity description D94976B89",
          "endTime": new Date('2024-01-14T13:31:09.254554'),
          "modifiedAt": new Date('2023-10-31T13:24:37.968360'),
          "name": "Activity N748306B6",
          "startTime": new Date('2023-08-21T17:08:28.809449'),
          "userId": "U0A56118E"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACTFBE62581",
              "concurrencyStamp": "CS67BC1F98",
              "createdAt": new Date('2023-08-19T23:54:26.969021'),
              "description": "Activity description D39EAA00D",
              "endTime": new Date('2024-01-04T01:30:16.859257'),
              "modifiedAt": new Date('2023-03-27T07:58:35.642380'),
              "name": "Activity NE72D8745",
              "startTime": new Date('2023-04-04T13:18:35.972007'),
              "userId": "U0AF79865"
            },
            {
              "activityId": "ACT8EB3BD22",
              "concurrencyStamp": "CSCE0F2070",
              "createdAt": new Date('2023-10-28T03:17:32.198876'),
              "description": "Activity description D5AA99F17",
              "endTime": new Date('2023-08-06T03:28:42.889849'),
              "modifiedAt": new Date('2023-09-27T10:29:29.595263'),
              "name": "Activity N584ABD1D",
              "startTime": new Date('2023-06-28T22:15:02.545883'),
              "userId": "U7C8775A0"
            },
            {
              "activityId": "ACTC0D8C764",
              "concurrencyStamp": "CSCE916810",
              "createdAt": new Date('2023-08-03T00:05:53.757639'),
              "description": "Activity description D3BED9DEB",
              "endTime": new Date('2023-03-08T10:02:29.735723'),
              "modifiedAt": new Date('2023-05-13T05:53:12.792124'),
              "name": "Activity N8D13B6B7",
              "startTime": new Date('2023-12-27T13:44:09.535680'),
              "userId": "UF12BD977"
            },
            {
              "activityId": "ACT4F0389F9",
              "concurrencyStamp": "CS1F4B4BD3",
              "createdAt": new Date('2023-04-07T05:09:55.795460'),
              "description": "Activity description D034AB120",
              "endTime": new Date('2024-01-01T11:12:27.725508'),
              "modifiedAt": new Date('2024-01-20T00:11:09.474136'),
              "name": "Activity N608EB337",
              "startTime": new Date('2023-03-11T10:19:07.795405'),
              "userId": "U62987D9F"
            },
            {
              "activityId": "ACTA23372CA",
              "concurrencyStamp": "CSCEBFA4DB",
              "createdAt": new Date('2024-01-21T23:36:52.957454'),
              "description": "Activity description DA2EAC2E5",
              "endTime": new Date('2023-03-03T21:27:58.429769'),
              "modifiedAt": new Date('2023-05-05T01:24:55.169651'),
              "name": "Activity NE05A34C0",
              "startTime": new Date('2023-06-11T00:19:02.110139'),
              "userId": "U25F6B7D7"
            }
          ],
          "concurrencyStamp": "CSA00C8FA5",
          "createdAt": new Date('2023-12-03T12:07:31.793275'),
          "description": "Job description DB2E19822",
          "isExpanded": false,
          "jobId": "JOBFF93F897",
          "modifiedAt": new Date('2023-01-29T21:35:24.153163'),
          "name": "Job Name NA87A393A",
          "userId": "U0E629173"
        },
        {
          "activities": [
            {
              "activityId": "ACTEC31C10E",
              "concurrencyStamp": "CS80CB7C71",
              "createdAt": new Date('2023-08-24T19:28:45.960702'),
              "description": "Activity description D0173A1A9",
              "endTime": new Date('2023-02-07T13:53:35.266203'),
              "modifiedAt": new Date('2023-03-21T05:38:37.415086'),
              "name": "Activity NBFC8CAE9",
              "startTime": new Date('2024-01-17T22:30:23.856405'),
              "userId": "U1047E25C"
            },
            {
              "activityId": "ACT850F9084",
              "concurrencyStamp": "CS74219C77",
              "createdAt": new Date('2023-11-14T03:30:14.659645'),
              "description": "Activity description D7BC22841",
              "endTime": new Date('2024-01-27T23:35:31.451882'),
              "modifiedAt": new Date('2023-07-24T21:08:35.642762'),
              "name": "Activity NE7A79A74",
              "startTime": new Date('2023-07-13T18:38:11.772994'),
              "userId": "U1CA626D5"
            },
            {
              "activityId": "ACTF76DDB11",
              "concurrencyStamp": "CS1F118471",
              "createdAt": new Date('2023-05-07T21:31:34.485418'),
              "description": "Activity description DEE052C2C",
              "endTime": new Date('2023-09-24T22:14:07.250270'),
              "modifiedAt": new Date('2023-08-17T11:53:09.802027'),
              "name": "Activity N7C2F35B8",
              "startTime": new Date('2023-12-27T03:22:22.627772'),
              "userId": "U4399CD72"
            },
            {
              "activityId": "ACT4A0947AE",
              "concurrencyStamp": "CSD4EB166F",
              "createdAt": new Date('2023-04-28T07:22:03.290574'),
              "description": "Activity description DB739A8D5",
              "endTime": new Date('2024-01-07T03:59:35.362802'),
              "modifiedAt": new Date('2023-07-27T21:29:30.276302'),
              "name": "Activity NA3AC4A6C",
              "startTime": new Date('2023-11-14T04:16:42.575486'),
              "userId": "UFA45CD71"
            }
          ],
          "concurrencyStamp": "CS2729F5CB",
          "createdAt": new Date('2023-02-21T07:37:49.737993'),
          "description": "Job description DC86BDFC0",
          "isExpanded": false,
          "jobId": "JOB236DEFD6",
          "modifiedAt": new Date('2023-10-01T16:23:48.928736'),
          "name": "Job Name N4DDDC3E5",
          "userId": "U30E96904"
        },
        {
          "activities": [
            {
              "activityId": "ACT040583B4",
              "concurrencyStamp": "CS2DCAA1A9",
              "createdAt": new Date('2023-08-26T06:01:26.390057'),
              "description": "Activity description DF67FEA81",
              "endTime": new Date('2023-02-23T09:42:54.101355'),
              "modifiedAt": new Date('2023-03-06T13:47:56.177556'),
              "name": "Activity N9198A366",
              "startTime": new Date('2023-05-02T07:50:31.583120'),
              "userId": "U8CE4CA4F"
            },
            {
              "activityId": "ACT2F54C271",
              "concurrencyStamp": "CS4E50613E",
              "createdAt": new Date('2023-12-25T10:11:53.787051'),
              "description": "Activity description DDA0A29D6",
              "endTime": new Date('2023-04-03T10:09:12.197410'),
              "modifiedAt": new Date('2024-01-12T03:56:48.167083'),
              "name": "Activity NF2908DB8",
              "startTime": new Date('2023-03-01T23:20:17.220179'),
              "userId": "U43E099B6"
            },
            {
              "activityId": "ACTB0F83856",
              "concurrencyStamp": "CS6113C3BE",
              "createdAt": new Date('2023-10-22T04:10:26.533447'),
              "description": "Activity description D9DE032D3",
              "endTime": new Date('2023-12-17T21:28:32.394080'),
              "modifiedAt": new Date('2023-03-16T21:15:30.161217'),
              "name": "Activity NF766F587",
              "startTime": new Date('2023-03-25T13:27:09.257171'),
              "userId": "U7CD34653"
            },
            {
              "activityId": "ACT69DDFB31",
              "concurrencyStamp": "CS3555BAA4",
              "createdAt": new Date('2023-07-09T14:23:42.448259'),
              "description": "Activity description D9B68E42A",
              "endTime": new Date('2023-12-16T15:34:24.907127'),
              "modifiedAt": new Date('2023-11-13T20:03:31.091549'),
              "name": "Activity NF83904A1",
              "startTime": new Date('2023-08-31T15:58:48.633230'),
              "userId": "U24ECF16D"
            },
            {
              "activityId": "ACTB5A981A9",
              "concurrencyStamp": "CSC1D3BE6E",
              "createdAt": new Date('2023-09-21T07:12:34.662968'),
              "description": "Activity description DE6218B2D",
              "endTime": new Date('2023-12-26T22:10:53.855107'),
              "modifiedAt": new Date('2023-07-09T02:09:51.372567'),
              "name": "Activity NDFD4D948",
              "startTime": new Date('2023-03-22T08:10:47.541533'),
              "userId": "U32480598"
            }
          ],
          "concurrencyStamp": "CSD5EB994A",
          "createdAt": new Date('2023-04-15T17:09:45.038992'),
          "description": "Job description D032F47C6",
          "isExpanded": false,
          "jobId": "JOB6F9E6017",
          "modifiedAt": new Date('2023-11-19T05:23:15.572333'),
          "name": "Job Name N793B1F83",
          "userId": "U5B985577"
        },
        {
          "activities": [
            {
              "activityId": "ACT5044B736",
              "concurrencyStamp": "CS9511431E",
              "createdAt": new Date('2023-11-23T16:26:43.436386'),
              "description": "Activity description D8D2628A4",
              "endTime": new Date('2023-10-15T13:00:17.231241'),
              "modifiedAt": new Date('2023-12-21T06:59:56.338016'),
              "name": "Activity N49AD3E2E",
              "startTime": new Date('2023-11-10T03:32:33.139092'),
              "userId": "U51DBA8CC"
            },
            {
              "activityId": "ACT0F30DE60",
              "concurrencyStamp": "CS8EC852F8",
              "createdAt": new Date('2023-12-17T20:58:12.034705'),
              "description": "Activity description DA4FC6AF2",
              "endTime": new Date('2023-07-03T09:26:50.699887'),
              "modifiedAt": new Date('2023-04-23T12:49:13.662532'),
              "name": "Activity N283260F1",
              "startTime": new Date('2023-05-15T21:55:15.473373'),
              "userId": "U5B0AD7C4"
            },
            {
              "activityId": "ACT1136543B",
              "concurrencyStamp": "CSA9273846",
              "createdAt": new Date('2024-01-07T22:40:49.527742'),
              "description": "Activity description DB2D56B69",
              "endTime": new Date('2023-01-31T05:33:23.628767'),
              "modifiedAt": new Date('2023-07-14T05:27:28.717592'),
              "name": "Activity N05E752DB",
              "startTime": new Date('2024-01-05T04:12:12.589310'),
              "userId": "UF28489EF"
            },
            {
              "activityId": "ACTB98030D1",
              "concurrencyStamp": "CSC55F3550",
              "createdAt": new Date('2023-05-01T23:50:47.627306'),
              "description": "Activity description DDADE4E45",
              "endTime": new Date('2023-07-11T19:52:50.406361'),
              "modifiedAt": new Date('2023-06-17T22:27:05.693770'),
              "name": "Activity NE438BF69",
              "startTime": new Date('2023-10-07T02:06:41.888116'),
              "userId": "U756A944E"
            }
          ],
          "concurrencyStamp": "CS760B06B6",
          "createdAt": new Date('2023-07-13T04:11:10.951092'),
          "description": "Job description D84AD23DA",
          "isExpanded": false,
          "jobId": "JOB334A14BA",
          "modifiedAt": new Date('2023-08-18T05:32:07.122326'),
          "name": "Job Name NE8B02EC6",
          "userId": "U056BF24A"
        }
      ],
      "modifiedAt": new Date('2023-09-03T11:01:00.067901'),
      "name": "Category NB9877C92",
      "status": 3,
      "userId": "U97BAB823"
    },
    {
      "categoryId": "CATAD834B38",
      "concurrencyStamp": "CSEBF19AE6",
      "createdAt": new Date('2023-07-19T23:40:50.653712'),
      "description": "Category description DF331D4E6",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACT0869A5D9",
          "concurrencyStamp": "CS6EB95789",
          "createdAt": new Date('2023-04-24T13:46:15.688689'),
          "description": "Activity description D74601F44",
          "endTime": new Date('2023-09-09T17:18:02.462596'),
          "modifiedAt": new Date('2023-09-19T01:40:43.117499'),
          "name": "Activity NF5226ECC",
          "startTime": new Date('2023-10-28T17:14:49.783309'),
          "userId": "UC18E609E"
        },
        {
          "activityId": "ACTE22AC6D8",
          "concurrencyStamp": "CS1B55A9ED",
          "createdAt": new Date('2023-12-07T12:54:53.315537'),
          "description": "Activity description DDF3375B7",
          "endTime": new Date('2023-07-12T20:21:53.629399'),
          "modifiedAt": new Date('2023-10-18T16:00:15.993830'),
          "name": "Activity NFF1A5D6A",
          "startTime": new Date('2023-07-20T09:08:00.886357'),
          "userId": "U71745E3A"
        },
        {
          "activityId": "ACT2DCE8205",
          "concurrencyStamp": "CS24FC34DB",
          "createdAt": new Date('2024-01-07T13:50:59.586603'),
          "description": "Activity description D3A29D493",
          "endTime": new Date('2023-09-29T08:38:22.652598'),
          "modifiedAt": new Date('2023-10-06T18:27:07.394775'),
          "name": "Activity N5257BF66",
          "startTime": new Date('2023-12-14T03:06:46.769733'),
          "userId": "UF75C29B8"
        },
        {
          "activityId": "ACT83C6A7CD",
          "concurrencyStamp": "CS58E44427",
          "createdAt": new Date('2023-08-24T14:09:03.024122'),
          "description": "Activity description D21FAC1C3",
          "endTime": new Date('2023-02-21T01:36:31.027878'),
          "modifiedAt": new Date('2023-09-17T21:08:30.994220'),
          "name": "Activity N4C956B1F",
          "startTime": new Date('2023-10-04T13:21:52.625053'),
          "userId": "UFBD206C5"
        },
        {
          "activityId": "ACT915ADF3D",
          "concurrencyStamp": "CS538118DF",
          "createdAt": new Date('2023-11-04T10:21:17.508838'),
          "description": "Activity description DED592AC5",
          "endTime": new Date('2023-04-29T10:00:40.934744'),
          "modifiedAt": new Date('2023-04-15T07:53:17.585994'),
          "name": "Activity N5B39B386",
          "startTime": new Date('2024-01-14T03:12:19.691042'),
          "userId": "UDEF7F589"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACT9FB09DF4",
              "concurrencyStamp": "CSDDD30300",
              "createdAt": new Date('2023-07-04T09:10:55.074515'),
              "description": "Activity description D95003C88",
              "endTime": new Date('2023-12-31T18:58:37.672078'),
              "modifiedAt": new Date('2023-11-21T16:37:08.661972'),
              "name": "Activity N035FBBE8",
              "startTime": new Date('2023-06-04T02:27:28.277813'),
              "userId": "U46F67680"
            },
            {
              "activityId": "ACT760477FB",
              "concurrencyStamp": "CS2EAFE3CF",
              "createdAt": new Date('2023-08-04T20:45:12.432355'),
              "description": "Activity description D35A511C7",
              "endTime": new Date('2023-03-08T03:20:25.502635'),
              "modifiedAt": new Date('2023-07-16T01:27:35.116790'),
              "name": "Activity N8A7A32A6",
              "startTime": new Date('2023-12-22T23:38:19.954989'),
              "userId": "UD1A1E8F4"
            },
            {
              "activityId": "ACTC20EFD7E",
              "concurrencyStamp": "CSED263B21",
              "createdAt": new Date('2023-11-26T13:39:04.435592'),
              "description": "Activity description D807C18F8",
              "endTime": new Date('2023-03-01T00:05:14.284332'),
              "modifiedAt": new Date('2024-01-06T14:46:17.002599'),
              "name": "Activity N4100982B",
              "startTime": new Date('2023-02-23T14:02:04.721806'),
              "userId": "UE6BC321B"
            },
            {
              "activityId": "ACTE5D07794",
              "concurrencyStamp": "CSB96C06DD",
              "createdAt": new Date('2023-10-24T16:21:55.201811'),
              "description": "Activity description DACF99690",
              "endTime": new Date('2023-10-20T03:19:49.538559'),
              "modifiedAt": new Date('2023-07-23T21:45:20.527732'),
              "name": "Activity N08DF22D1",
              "startTime": new Date('2023-11-30T16:50:40.689304'),
              "userId": "U0F1D234D"
            }
          ],
          "concurrencyStamp": "CSC900F1E1",
          "createdAt": new Date('2023-11-01T10:19:37.889776'),
          "description": "Job description D9195199D",
          "isExpanded": false,
          "jobId": "JOB4228EA47",
          "modifiedAt": new Date('2023-11-09T01:18:47.170298'),
          "name": "Job Name N59F5FAC8",
          "userId": "U673CD3D9"
        },
        {
          "activities": [
            {
              "activityId": "ACT5A7C4EFD",
              "concurrencyStamp": "CS64959E80",
              "createdAt": new Date('2023-09-04T09:40:28.240094'),
              "description": "Activity description D6283548D",
              "endTime": new Date('2023-03-01T03:34:03.399718'),
              "modifiedAt": new Date('2023-09-18T21:16:02.248297'),
              "name": "Activity NE37EA58D",
              "startTime": new Date('2023-10-23T00:01:54.705932'),
              "userId": "UDAB34282"
            },
            {
              "activityId": "ACTDEC07F2C",
              "concurrencyStamp": "CS429AB1F2",
              "createdAt": new Date('2023-01-29T21:53:34.697487'),
              "description": "Activity description DDFD0C6D7",
              "endTime": new Date('2023-10-12T00:57:18.982979'),
              "modifiedAt": new Date('2023-06-08T12:25:25.898853'),
              "name": "Activity NBDD1F6D0",
              "startTime": new Date('2024-01-12T15:48:26.903310'),
              "userId": "U1433C255"
            },
            {
              "activityId": "ACT1CC64A4D",
              "concurrencyStamp": "CS2F04C0B5",
              "createdAt": new Date('2023-07-08T20:33:32.863971'),
              "description": "Activity description D952923FC",
              "endTime": new Date('2024-01-21T07:02:20.998348'),
              "modifiedAt": new Date('2023-04-23T13:28:05.838065'),
              "name": "Activity NFD826AAF",
              "startTime": new Date('2023-05-23T13:30:42.975002'),
              "userId": "U3683E92E"
            },
            {
              "activityId": "ACT8F46F4E3",
              "concurrencyStamp": "CS442A60BD",
              "createdAt": new Date('2023-12-05T14:45:54.653302'),
              "description": "Activity description D5C9DB87E",
              "endTime": new Date('2023-12-23T04:07:17.603327'),
              "modifiedAt": new Date('2023-03-03T05:35:37.578854'),
              "name": "Activity N2B7078A8",
              "startTime": new Date('2023-03-09T16:05:27.266167'),
              "userId": "UEB41D6AA"
            }
          ],
          "concurrencyStamp": "CS0DCD2218",
          "createdAt": new Date('2023-11-06T13:45:31.167575'),
          "description": "Job description D6DEBCED8",
          "isExpanded": false,
          "jobId": "JOB10F9CB8F",
          "modifiedAt": new Date('2023-06-01T06:20:24.314967'),
          "name": "Job Name N96E13AAF",
          "userId": "U4CA150B1"
        },
        {
          "activities": [
            {
              "activityId": "ACT9965EEE9",
              "concurrencyStamp": "CS90AF1B16",
              "createdAt": new Date('2023-11-30T21:57:33.401830'),
              "description": "Activity description D8FBBB350",
              "endTime": new Date('2023-02-18T19:27:08.752834'),
              "modifiedAt": new Date('2023-05-27T03:50:17.216580'),
              "name": "Activity N17424D06",
              "startTime": new Date('2023-04-08T18:03:10.006548'),
              "userId": "U34DCFEAA"
            },
            {
              "activityId": "ACT25DC5357",
              "concurrencyStamp": "CSDCA5A0B5",
              "createdAt": new Date('2023-03-01T04:07:49.542281'),
              "description": "Activity description D7E10EE99",
              "endTime": new Date('2023-10-15T04:46:33.422645'),
              "modifiedAt": new Date('2023-03-11T15:55:28.736007'),
              "name": "Activity NDB31F6C6",
              "startTime": new Date('2023-01-30T18:49:41.944015'),
              "userId": "UED82E67F"
            }
          ],
          "concurrencyStamp": "CSE5ECD6A5",
          "createdAt": new Date('2023-09-01T04:42:21.501803'),
          "description": "Job description D22CDAB04",
          "isExpanded": false,
          "jobId": "JOBA546818E",
          "modifiedAt": new Date('2023-10-27T00:32:46.994678'),
          "name": "Job Name NBEF881B7",
          "userId": "UE43D298C"
        }
      ],
      "modifiedAt": new Date('2023-06-29T04:29:12.710984'),
      "name": "Category NAC832A01",
      "status": 1,
      "userId": "UF0484731"
    },
    {
      "categoryId": "CAT25CD59CA",
      "concurrencyStamp": "CS8D318B13",
      "createdAt": new Date('2023-05-10T13:51:22.410262'),
      "description": "Category description D37A50986",
      "isExpanded": false,
      "activities": [
        {
          "activityId": "ACTF7BCF044",
          "concurrencyStamp": "CS398B384F",
          "createdAt": new Date('2023-09-22T00:25:11.534203'),
          "description": "Activity description DA5F0FED1",
          "endTime": new Date('2023-08-29T19:58:46.342644'),
          "modifiedAt": new Date('2023-09-29T05:21:42.952391'),
          "name": "Activity N73F69556",
          "startTime": new Date('2023-05-13T09:49:21.505588'),
          "userId": "U74493323"
        },
        {
          "activityId": "ACT590A9EC6",
          "concurrencyStamp": "CS3368F1E1",
          "createdAt": new Date('2023-09-11T05:02:44.644797'),
          "description": "Activity description D49A8DB19",
          "endTime": new Date('2023-06-23T19:05:53.167714'),
          "modifiedAt": new Date('2023-03-27T04:05:54.981501'),
          "name": "Activity NE67B086C",
          "startTime": new Date('2023-03-23T09:31:48.905884'),
          "userId": "UFB44CAB7"
        }
      ],
      "jobs": [
        {
          "activities": [
            {
              "activityId": "ACTEB4FCFC9",
              "concurrencyStamp": "CS0E8CDE1C",
              "createdAt": new Date('2023-05-10T14:51:55.299756'),
              "description": "Activity description D6D1B80AC",
              "endTime": new Date('2023-04-03T01:23:22.911955'),
              "modifiedAt": new Date('2023-09-21T12:20:03.859484'),
              "name": "Activity N91F96A10",
              "startTime": new Date('2023-09-11T05:50:52.142899'),
              "userId": "U0BF001E8"
            },
            {
              "activityId": "ACT49669F45",
              "concurrencyStamp": "CS3F94099D",
              "createdAt": new Date('2023-03-29T20:45:03.686119'),
              "description": "Activity description D0D66C503",
              "endTime": new Date('2023-12-30T10:15:10.696682'),
              "modifiedAt": new Date('2023-03-07T07:06:49.128174'),
              "name": "Activity N80BDC086",
              "startTime": new Date('2023-11-10T10:15:09.479936'),
              "userId": "U71C5EA77"
            },
            {
              "activityId": "ACTE7013FF4",
              "concurrencyStamp": "CS6F7DE56F",
              "createdAt": new Date('2023-06-13T16:48:31.345245'),
              "description": "Activity description DAAEBF678",
              "endTime": new Date('2023-05-02T04:53:37.565939'),
              "modifiedAt": new Date('2023-11-25T14:55:52.807888'),
              "name": "Activity N7014A048",
              "startTime": new Date('2023-05-28T12:48:49.413394'),
              "userId": "U2E50573C"
            },
            {
              "activityId": "ACT2801A6E8",
              "concurrencyStamp": "CS9AFD7B98",
              "createdAt": new Date('2023-06-26T16:25:22.860849'),
              "description": "Activity description D34A089D1",
              "endTime": new Date('2023-06-01T11:33:24.787599'),
              "modifiedAt": new Date('2024-01-09T14:15:01.496133'),
              "name": "Activity N53226200",
              "startTime": new Date('2023-10-09T16:01:40.148900'),
              "userId": "U3031FC1D"
            }
          ],
          "concurrencyStamp": "CSEDF701A0",
          "createdAt": new Date('2023-12-12T18:37:34.010723'),
          "description": "Job description D1DCF5DF3",
          "isExpanded": false,
          "jobId": "JOB0F4756A1",
          "modifiedAt": new Date('2023-05-18T02:30:38.783756'),
          "name": "Job Name N800765EB",
          "userId": "U197DFEDC"
        },
        {
          "activities": [
            {
              "activityId": "ACT78ACD6C6",
              "concurrencyStamp": "CS79439763",
              "createdAt": new Date('2023-05-17T15:09:47.947340'),
              "description": "Activity description D425AE3C5",
              "endTime": new Date('2023-07-02T03:50:07.207325'),
              "modifiedAt": new Date('2023-09-04T22:05:53.204233'),
              "name": "Activity N2A3E0C07",
              "startTime": new Date('2023-11-28T19:49:41.881860'),
              "userId": "U005941B6"
            },
            {
              "activityId": "ACT986E50CC",
              "concurrencyStamp": "CSBD67BC38",
              "createdAt": new Date('2023-09-03T14:08:55.428293'),
              "description": "Activity description D23D164A7",
              "endTime": new Date('2024-01-19T15:34:13.314640'),
              "modifiedAt": new Date('2023-07-16T19:55:44.994561'),
              "name": "Activity N3E30E170",
              "startTime": new Date('2024-01-09T20:17:54.931727'),
              "userId": "U9AE1BACB"
            },
            {
              "activityId": "ACTC59580FE",
              "concurrencyStamp": "CS4162C877",
              "createdAt": new Date('2024-01-13T07:10:05.046547'),
              "description": "Activity description D3A24244C",
              "endTime": new Date('2023-07-20T00:07:18.978393'),
              "modifiedAt": new Date('2023-12-07T13:15:20.702706'),
              "name": "Activity N3709F6B0",
              "startTime": new Date('2023-03-13T11:55:56.561141'),
              "userId": "UDEB30DDA"
            }
          ],
          "concurrencyStamp": "CS1D1B529F",
          "createdAt": new Date('2023-04-29T15:51:47.105776'),
          "description": "Job description D5C4F0A4D",
          "isExpanded": false,
          "jobId": "JOB24C639B4",
          "modifiedAt": new Date('2023-05-04T07:17:49.598513'),
          "name": "Job Name N0D00DA29",
          "userId": "U0E6D8EA4"
        },
        {
          "activities": [
            {
              "activityId": "ACT617A92D9",
              "concurrencyStamp": "CS4D1FBA2D",
              "createdAt": new Date('2023-04-22T02:51:50.285307'),
              "description": "Activity description D34AE1E6D",
              "endTime": new Date('2023-03-03T06:03:16.388320'),
              "modifiedAt": new Date('2023-03-16T06:07:30.033407'),
              "name": "Activity N3B2B8C16",
              "startTime": new Date('2023-03-23T23:07:23.061155'),
              "userId": "U54BB99D4"
            },
            {
              "activityId": "ACT05955BFF",
              "concurrencyStamp": "CS0E999760",
              "createdAt": new Date('2023-07-24T04:25:44.343396'),
              "description": "Activity description D20C71532",
              "endTime": new Date('2023-03-01T17:38:15.987119'),
              "modifiedAt": new Date('2023-08-07T03:09:00.136312'),
              "name": "Activity N8C200D17",
              "startTime": new Date('2024-01-15T01:12:11.967134'),
              "userId": "U6283B620"
            }
          ],
          "concurrencyStamp": "CS9D93E284",
          "createdAt": new Date('2024-01-08T06:00:40.778427'),
          "description": "Job description DCC34600B",
          "isExpanded": false,
          "jobId": "JOB397F039C",
          "modifiedAt": new Date('2023-11-07T07:36:34.430723'),
          "name": "Job Name N0D76FF4A",
          "userId": "U6F0551BA"
        }
      ],
      "modifiedAt": new Date('2023-05-07T04:16:55.296798'),
      "name": "Category N0AC10579",
      "status": 4,
      "userId": "UE1CC5C8B"
    }
  ];

  toggle(treeItem: Expandable) {
    treeItem.isExpanded = !treeItem.isExpanded;
  }
}
