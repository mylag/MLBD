/* FUGE-LC Reference script 

	Author: JPA
	Date  : 01-2010

 	Note: the name of the functions cannot be changed 							
*/

// Experiment name appearing in the logs
experimentName = "mlbd2017snespe";

// Directory where logs, fuzzy systems and temporary files are saved
savePath = "/home/mlbd/Desktop/mileRsltSenSpe/";

// Fuzzy system parameters 
fixedVars = false;
nbRules = 5;
nbMaxVarPerRule = 5;
nbOutVars = 1;
nbInSets = 2;
nbOutSets = 2;
inVarsCodeSize = 8;
outVarsCodeSize = 1;
inSetsCodeSize = 2;
outSetsCodeSize = 1;
inSetsPosCodeSize = 7;
outSetPosCodeSize = 1;

// Co-evolution parameters
// Population 1: Membership Functions (Variables)
maxGenPop1 = 200;
maxFitPop1 = 0.99;
elitePop1 = 5;
popSizePop1 = 200;
cxProbPop1 = 0.9;
mutFlipIndPop1 = 0.2;
mutFlipBitPop1 = 0.025;

// Population 2: Rules
elitePop2 = 5;
popSizePop2 = 200;
cxProbPop2 = 0.6;
mutFlipIndPop2 = 0.5;
mutFlipBitPop2 = 0.025;

// Fitness parameters
sensitivityW = 1.0;
specificityW = 1.0;
accuracyW = 0.0;
ppvW = 1.0;
rmseW = 0.5;
rrseW = 0.0;
raeW = 0.0;
mxeW = 0.0;
distanceThresholdW = 0.0;
distanceMinThresholdW = 0.0;
dontCareW = 0.1;
overLearnW = 0.0;
threshold = 0.5;
threshActivated = true;

function doSetParams()
{
	this.setParams(experimentName, savePath, fixedVars, nbRules, nbMaxVarPerRule, nbOutVars, nbInSets, nbOutSets, inVarsCodeSize, outVarsCodeSize, 
				 inSetsCodeSize, outSetsCodeSize, inSetsPosCodeSize, outSetPosCodeSize, maxGenPop1, maxFitPop1, elitePop1, popSizePop1, 
				 cxProbPop1, mutFlipIndPop1, mutFlipBitPop1, maxGenPop1, maxFitPop1, elitePop2, popSizePop2, cxProbPop2, mutFlipIndPop2, 
				 mutFlipBitPop2, sensitivityW, specificityW, accuracyW, ppvW, rmseW, rrseW, raeW, mxeW, distanceThresholdW,
			         distanceMinThresholdW, dontCareW, overLearnW, threshold, threshActivated);
}

// Run function called by FUGE-LC. This function MUST also be present
function doRun() 
{
	var nbGens = [100];
	var popVals = [200];	
	var nRuleVals = [3];
	var nMaxVarPRule = [3];
	var alphaValues = [0.2, 0.4, 0.6, 0.8, 1.0];
	var qtyExp = 5;
	rmseW = 1.0;
	dontCareW = 0.5;

	// Multiple coevolution runs with different parameters
	for (var i = 0; i < nbGens.length; i++) {
		for(var j = 0; j < popVals.length; j++) {
			for (var k = 0; k < nRuleVals.length; k++) {
				for (var l = 0; l < nMaxVarPRule.length; l++) {
					for (m = 0; m < alphaValues.length; m++)
					{
						sensitivityW = 1-alphaValues[m];
						specificityW = alphaValues[m];
						for (var n = 0; n < qtyExp; n++) {
							maxGenPop1 = nbGens[i]
							popSizePop1 = popVals[j];
							popSizePop2 = popVals[j];
							nbRules = nRuleVals[k];
							nbMaxVarPerRule = nMaxVarPRule[l]			
							this.runEvo();
						}
					}
				}
			}
		}
	}
}
// EOF
