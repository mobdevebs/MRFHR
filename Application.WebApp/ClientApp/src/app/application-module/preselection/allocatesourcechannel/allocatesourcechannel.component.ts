import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ISearchRequisition, IRequisitionList, IRequsitionSourceChannelFeature,IRequisitionSourceFormData } from '../../../interfaces/preselection/requisition.interface';
import { IVendor, ISearchVendor } from '../../../interfaces/vendor/vendor.interface';
import { ShareddataService } from '../../../sharedservices/shareddata.service';
import { RequisitionService } from '../../../services/preselection/requisition/requisition.service';
import { VendorService } from '../../../services/vendor/vendor/vendor.service';
declare var jQuery: any;

@Component({
  selector: 'app-allocatesourcechannel',
  templateUrl: './allocatesourcechannel.component.html',
  styleUrls: ['./allocatesourcechannel.component.css']
})
export class AllocatesourcechannelComponent implements OnInit {
  requisitionDetailHistoryId: number;
  requisitionLists: IRequisitionList[] = [];
  searchRequisition: ISearchRequisition = {
    requisitionNo: null,
    requistionId: null,
    requisitionDetailHistoryId: null,
    locationId: null,
    verticalId: null,
    fromDate: null,
    toDate: null,
    iOMNo: null,
    requisitionApprovalStatus: null,
    requisitionProcessStatus: null,
    createdBy: null,
    approverAutoUserId: null
  }
  sourceChannelFeature: IRequsitionSourceChannelFeature[] = [];
  formData:IRequisitionSourceFormData={
    RequisitionDetailHistoryId:null,
    VendorIds:null,
    SourceChannelFeature:null,
    CreatedBy:null
  };
  //vendors
  vendors: IVendor[] = [];
  selectedVendor: number[] = [];
  searchVendor: ISearchVendor = {
    vendorId: null,
    isActive: null
  }
  isSourceChannel1Disable: boolean = true;
  isSourceChannel2Disable: boolean = true;
  isSourceChannel3Disable: boolean = true;
  isSourceChannel4Disable: boolean = true;
  isSourceChannel5Disable: boolean = true;
  constructor(
    private fb: FormBuilder,
    private shareddataService: ShareddataService,
    private requisitionService: RequisitionService,
    private vendorService: VendorService
  ) {
    this.requisitionDetailHistoryId = this.shareddataService.getData();
    console.log(this.requisitionDetailHistoryId);
    this.getRequisitionDetail();
    this.getAllVendor();
  }

  ngOnInit() {
  }

  getRequisitionDetail() {
    this.requisitionLists = [];
    this.searchRequisition.requisitionDetailHistoryId = this.requisitionDetailHistoryId;
    this.requisitionService.getAllRequisition(this.searchRequisition).subscribe((result) => {
      if (result) {
        console.log(result);
        this.requisitionLists = result;
        console.log(result);
      }
      else {
        this.requisitionLists = [];
      }
    }, error => {
      console.log(error);
    }, () => {
    });
  }

  getAllVendor() {
    this.vendors = [];
    this.searchVendor.isActive = true;
    this.searchVendor.vendorId = 0;
    console.log(this.searchVendor);
    this.vendorService.getAllVendor(this.searchVendor).subscribe((result) => {
      if (result) {
        this.vendors = result;
      }
      else {
        this.vendors = [];
      }
    }, error => {
      console.log(error);
    }, () => {
      this.loadSelectPicker();
    });
  }

  loadSelectPicker() {
    setTimeout(() => {
      jQuery('.selectpicker').selectpicker({
        size: 6
      });
      jQuery('.selectpicker').selectpicker('refresh');
    });
  }

  enableCheckBox(evt, id) {
    if (id == "1") {
      if (evt.target.checked == true) {
        this.isSourceChannel1Disable = false;
      }
      else {
        this.isSourceChannel1Disable = true;
        jQuery(".chkchannel1").prop("checked", false);
        jQuery(".txtchannel1").val("");
      }
    }
    if (id == "2") {
      if (evt.target.checked == true) {
        this.isSourceChannel2Disable = false;
      }
      else {
        this.isSourceChannel2Disable = true;
        jQuery(".chkchannel2").prop("checked", false);
        jQuery(".txtchannel2").val("");
      }
    }
    if (id == "3") {
      if (evt.target.checked == true) {
        this.isSourceChannel3Disable = false;
      }
      else {
        this.isSourceChannel3Disable = true;
        jQuery(".chkchannel3").prop("checked", false);
        jQuery(".txtchannel3").val("");
      }
    }
    if (id == "4") {
      if (evt.target.checked == true) {
        this.isSourceChannel4Disable = false;
      }
      else {
        this.isSourceChannel4Disable = true;
        jQuery(".chkchannel4").prop("checked", false);
        jQuery(".txtchannel4").val("");
      }
    }
  }

  changeselectedVendor() {
    if (this.selectedVendor.length == 0) {
      this.isSourceChannel5Disable = true;
    }
    else {
      this.isSourceChannel5Disable = false;
      jQuery(".chkchannel5").prop("checked", false);
      jQuery(".txtchannel5").val("");
    }
  }

  submitForm() {
    var dothis = this;
    var i = 1;
    dothis.sourceChannelFeature = [];
    jQuery("#tbodyfeature").find("tr").each(function () {
      var j = 1;
      var notes = jQuery(this).find("td:last").find("input[type='text']").val();
      jQuery(this).find("td:not(:first, :last)").each(function () {
        if (jQuery(this).find("input[type='checkbox']").prop("checked") == true) {
          dothis.sourceChannelFeature.push({ SourceChannelId: i, JobDescriptionFeatureId: j, Notes: notes });

        }
        j++;
      });
      i++
    });
    dothis.formData.RequisitionDetailHistoryId=dothis.requisitionDetailHistoryId;
    dothis.formData.SourceChannelFeature=dothis.sourceChannelFeature;
    dothis.formData.CreatedBy=1;
    dothis.formData.VendorIds=dothis.selectedVendor.join();
    dothis.requisitionService.allocateSourceChannel(dothis.formData).subscribe((result) => {
      if (result) {
        console.log(result);
      }
      else {
        console.log(result);
      }
    }, error => {
      console.log(error);
    }, () => {
      this.loadSelectPicker();
    });
  }
}
