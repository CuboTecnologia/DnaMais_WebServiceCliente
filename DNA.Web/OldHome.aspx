﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OldHome.aspx.cs" Inherits="DNA.Web.OldHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DNA+</title>
    <!-- Basic -->
    <meta charset="UTF-8">
    <meta name="keywords" content="ECRV Consulta Online Veiculos Veiculo Veicular Veiculares Protestos Restritivo BIN Base Nacional Agregado Leilão Sinistro CPF CNPJ Empresa Estadual PT Multa Renavam Chassi Placa Gravame Infração">
    <meta name="description" content="Solução completa em consulta de dados on-line">
    <meta name="author" content="Equipe de Sistemas DNA+" />

    		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"> 

		<!-- Web Fonts  -->
		<link href="./pages-signin_files/css" rel="stylesheet" type="text/css">

		<!-- Vendor CSS -->
		<link rel="stylesheet" href="css/bootstrap.css">
		<link rel="stylesheet" href="css/font-awesome.css">
		<link rel="stylesheet" href="css/magnific-popup.css">
		<link rel="stylesheet" href="css/datepicker3.css"> 

		<!-- Theme CSS -->
		<link rel="stylesheet" href="css/theme.css">

		<!-- Theme Custom CSS -->
		<link rel="stylesheet" href="http://preview.oklerthemes.com/porto-admin/1.3.0/assets/stylesheets/theme-custom.css">

		<!-- Head Libs 
		<script async="" src="./pages-signin_files/analytics.js"></script><script src="./pages-signin_files/modernizr.js"></script>-->

	    <link rel="stylesheet" href="css/style-switcher.css">
        <link rel="stylesheet/less" href="css/skin.less">
        <style type="text/css" id="less:porto-admin-1:3:0-assets-vendor-style-switcher-less-skin">/* Base */
        a,
        .btn-link {
          color: #0088cc;
        }
        a:hover,
        a:focus,
        .btn-link:hover,
        .btn-link:focus {
          color: #0099e6;
        }
        a:active,
        .btn-link:active {
          color: #0077b3;
        }
        /* Sidebar Left */
        .sidebar-left .sidebar-header .sidebar-toggle:hover i {
          color: #0088cc;
        }
        @media only screen and (min-width: 768px) {
          html.sidebar-left-collapsed.scroll .sidebar-left .nav-main li.nav-active a:hover,
          html.sidebar-left-collapsed.boxed .sidebar-left .nav-main li.nav-active a:hover {
            color: #0088cc;
          }
          html.sidebar-left-collapsed.scroll .sidebar-left .nav-main > li:hover > a span.label,
          html.sidebar-left-collapsed.boxed .sidebar-left .nav-main > li:hover > a span.label {
            background-color: #0088cc;
          }
        }
        /* Layout Boxed - small than min-width */
        @media only screen and (max-width: 1199px) {
          html.boxed .header {
            border-top-color: #0088cc;
          }
        }
        /* Layout Boxed - larger or equal min width */
        @media only screen and (min-width: 1200px) {
          html.boxed .header {
            border-top-color: #0088cc;
          }
          html.boxed .sidebar-right {
            border-top-color: #0088cc;
            min-height: 0;
          }
        }
        /* Userbox - Open */
        .userbox.open .dropdown-menu a:hover {
          background: #0088cc;
        }
        /* Mailbox */
        .mailbox .mailbox-mail-list li.active {
          background: #0088cc;
        }
        .mailbox .mailbox-mail .mailbox-close-mail {
          color: #0088cc;
        }
        .mailbox .mailbox-mail .mailbox-close-mail:hover {
          color: #0099e6;
        }
        .mailbox .mailbox-mail .panel .panel-heading .panel-actions a:hover {
          color: #0088cc;
        }
        /* Media Gallery */
        .media-gallery ul.mg-tags > li a:hover {
          background-color: #0088cc;
        }
        .media-gallery .mg-files .thumbnail .thumb-preview .mg-thumb-options .mg-zoom {
          background-color: #0088cc;
        }
        .media-gallery .mg-files .thumbnail .thumb-preview .mg-thumb-options .mg-toolbar {
          background-color: #0088cc;
        }
        .media-gallery .mg-files .thumbnail.thumbnail-selected {
          box-shadow: 0 0 8px -1px #0088cc;
        }
        /* Sign Screens - Wrappers */
        .body-sign .panel-sign .panel-title-sign .title {
          background-color: #E43135;
        }
        .body-sign .panel-sign .panel-body {
          border-top-color: #E43135;
        }
        /* Lock Screen */
        .body-locked .current-user .user-image {
          border-color: #0088cc;
        }
        /* Blockquote */
        blockquote.primary {
          border-color: #0088cc;
        }
        /* Nav Pills */
        .nav-pills-primary > li a:hover,
        .nav-pills-primary > li a:focus {
          color: #0088cc;
          background-color: #cceeff;
        }
        .nav-pills-primary > li.active > a,
        .nav-pills-primary > li.active > a:hover,
        .nav-pills-primary > li.active > a:active,
        .nav-pills-primary > li.active > a:focus {
          background-color: #0088cc;
        }
        /* Dropdown Menu */
        .dropdown-menu  > .active  > a,
        .dropdown-menu  > .active  > a:hover,
        .dropdown-menu  > .active  > a:focus {
          background-color: #0088cc;
        }
        .open > .dropdown-toggle.btn-primary {
          background: #0088cc;
          border-color: #0077b3;
        }
        body .btn-primary.dropdown-toggle {
          border-left-color: #00a3f5;
        }
        /* Buttons */
        body .btn-primary {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #E43135;
          border-color: #E43135;
        }
        body .btn-primary:hover {
          border-color: #ff0000 !important;
          background-color: #ff0000;          
        }
        body .btn-primary:active,
        body .btn-primary:focus {
          border-color: #0077b3 !important;
          background-color: #0077b3;
        }
        body .btn-primary[disabled] {
          border-color: #33bbff !important;
          background-color: #33bbff;
        }
        body .btn-success {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #47a447;
          border-color: #47a447;
        }
        body .btn-success:hover {
          border-color: #51b451 !important;
          background-color: #51b451;
        }
        body .btn-success:active,
        body .btn-success:focus {
          border-color: #3f923f !important;
          background-color: #3f923f;
        }
        body .btn-success[disabled] {
          border-color: #86cb86 !important;
          background-color: #86cb86;
        }
        body .btn-warning {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #ed9c28;
          border-color: #ed9c28;
        }
        body .btn-warning:hover {
          border-color: #efa740 !important;
          background-color: #efa740;
        }
        body .btn-warning:active,
        body .btn-warning:focus {
          border-color: #e89113 !important;
          background-color: #e89113;
        }
        body .btn-warning[disabled] {
          border-color: #f5c786 !important;
          background-color: #f5c786;
        }
        body .btn-danger {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #d2322d;
          border-color: #d2322d;
        }
        body .btn-danger:hover {
          border-color: #d64742 !important;
          background-color: #d64742;
        }
        body .btn-danger:active,
        body .btn-danger:focus {
          border-color: #bd2d29 !important;
          background-color: #bd2d29;
        }
        body .btn-danger[disabled] {
          border-color: #e48481 !important;
          background-color: #e48481;
        }
        body .btn-info {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #5bc0de;
          border-color: #5bc0de;
        }
        body .btn-info:hover {
          border-color: #70c8e2 !important;
          background-color: #70c8e2;
        }
        body .btn-info:active,
        body .btn-info:focus {
          border-color: #46b8da !important;
          background-color: #46b8da;
        }
        body .btn-info[disabled] {
          border-color: #b0e1ef !important;
          background-color: #b0e1ef;
        }
        body .btn-dark {
          color: #ffffff;
          text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
          background-color: #171717;
          border-color: #171717;
        }
        body .btn-dark:hover {
          border-color: #242424 !important;
          background-color: #242424;
        }
        body .btn-dark:active,
        body .btn-dark:focus {
          border-color: #0a0a0a !important;
          background-color: #0a0a0a;
        }
        body .btn-dark[disabled] {
          border-color: #4a4a4a !important;
          background-color: #4a4a4a;
        }
        /* Switch*/
        .switch.switch-primary .ios-switch .on-background {
          background: #0088cc;
        }
        /* Label */
        .label-primary {
          background: #0088cc;
        }
        /* Text Primary */
        .text-primary {
          color: #0088cc !important;
        }
        /* BG Primary */
        .bg-primary {
          background: #0088cc;
        }
        /* Alternative Font Style */
        .alternative-font {
          color: #0088cc;
        }
        /* Hightlight */
        .highlight {
          background-color: #0088cc;
        }
        /* Drop Caps */
        p.drop-caps.colored:first-child:first-letter {
          color: #0088cc;
        }
        p.drop-caps.colored.secundary:first-child:first-letter {
          background-color: #0088cc;
        }
        /* Well */
        .well.primary {
          background: #0088cc;
          border-color: #006699;
        }
        /* Form */
        .form-control:focus {
          border-color: #E53036;
          box-shadow: 0 1px 1px #F6B2B4 inset, 0 0 8px #F6B2B4;
        }
        /* Header */
        .header .toggle-sidebar-left {
          background: #0088cc;
        }
        /* Page Header */
        .page-header h2 {
          border-bottom-color: #0088cc;
        }
        .page-header .sidebar-right-toggle:hover {
          color: #0088cc;
        }
        /* Navigation */
        ul.nav-main > li.nav-active > a {
          box-shadow: 2px 0 0 #0088cc inset;
        }
        ul.nav-main > li.nav-active > i {
          color: #0088cc;
        }
        ul.nav-main li .nav-children li.nav-active > a {
          color: #0088cc;
        }
        /* Nano Scroller Plugin */
        html.no-overflowscrolling .nano > .nano-pane > .nano-slider {
          background: #0088cc;
        }
        /* Nav Pills */
        .nav-pills > .active a,
        .nav-pills > .active a:hover,
        .nav-pills > .active a:focus {
          background-color: #0088cc;
        }
        /* Pagination */
        .pagination > li a {
          color: #0088cc;
        }
        .pagination > li a:hover,
        .pagination > li a:focus {
          color: #0099e6;
        }
        .pagination > li.active a,
        .pagination > li.active span,
        .pagination > li.active a:hover,
        .pagination > li.active span:hover,
        .pagination > li.active a:focus,
        .pagination > li.active span:focus {
          background-color: #0088cc;
          border-color: #0088cc;
        }
        .pagination > li.active a {
          background-color: #0088cc;
        }
        html .pagination > li.active a,
        html.dark .pagination > li.active a,
        html .pagination > li.active span,
        html.dark .pagination > li.active span,
        html .pagination > li.active a:hover,
        html.dark .pagination > li.active a:hover,
        html .pagination > li.active span:hover,
        html.dark .pagination > li.active span:hover,
        html .pagination > li.active a:focus,
        html.dark .pagination > li.active a:focus,
        html .pagination > li.active span:focus,
        html.dark .pagination > li.active span:focus {
          background-color: #0088cc;
          border-color: #0088cc;
        }
        html .pagination > li.active a,
        html.dark .pagination > li.active a {
          background-color: #0088cc;
        }
        /* Fullcalendar */
        .fc .fc-widget-header {
          background: #0088cc;
          border-color: #0088cc;
        }
        .fc .fc-header-title h2:before {
          color: #0088cc;
        }
        .fc-event {
          background: #0088cc;
          border-color: #0088cc;
        }
        .fc-event.fc-event-primary {
          background: #0088cc;
          border-color: #0088cc;
        }
        /* Maps */
        .jqvmap-zoomin,
        .jqvmap-zoomout {
          background: #0088cc;
        }
        /* Timeline */
        .timeline .tm-items > li .tm-datetime .tm-datetime-time {
          color: #0088cc;
        }
        .timeline .tm-items > li .tm-icon {
          border-color: #0088cc;
          color: #0088cc;
        }
        .timeline.timeline-simple .tm-body .tm-items > li:before {
          background: #0088cc;
          box-shadow: 0 0 0 3px #ffffff, 0 0 0 6px #0088cc;
        }
        html.dark .timeline.timeline-simple .tm-body .tm-items > li:before {
          background: #0088cc;
          box-shadow: 0 0 0 3px #2e353e, 0 0 0 6px #0088cc;
        }
        /* Princing Table */
        .pricing-table h3 span {
          color: #0088cc;
        }
        .pricing-table .most-popular h3 {
          background-color: #0088cc !important;
          color: #ffffff !important;
        }
        /* Data Tables Loading */
        .dataTables_processing {
          background-color: #0088cc;
        }
        /* Accordion */
        .panel-group .panel-accordion .panel-heading a {
          color: #0088cc;
        }
        /* Alerts */
        .alert-primary {
          background-color: #0088cc;
          border-color: #007ebd;
        }
        .alert-primary .alert-link {
          color: #004466;
        }
        /* Nestable */
        .dd-handle:hover {
          color: #0088cc !important;
        }
        .dd-placeholder {
          background: #e6f7ff;
          border-color: #0088cc;
        }
        /* Panels */
        .panel-highlight .panel-heading {
          background-color: #0088cc;
          border-color: #0088cc;
        }
        .panel-highlight .panel-body {
          background-color: #0088cc;
        }
        html .panel-primary .panel-heading {
          background: #0088cc;
          border-color: #0088cc;
        }
        .panel-heading.bg-primary {
          background: #0088cc;
        }
        .panel-body.bg-primary {
          background: #0088cc;
        }
        .panel-featured-primary {
          border-color: #0088cc;
        }
        .panel-featured-primary .panel-title {
          color: #0088cc;
        }
        .panel-heading-icon.bg-primary {
          background: #0088cc;
        }
        .panel-group .panel-accordion-primary .panel-heading .panel-title a {
          background: #0088cc;
        }
        /* Progress Bar */
        .progress-bar {
          background-color: #0088cc;
        }
        .progress .progress-bar-primary {
          background-color: #0088cc;
        }
        /* Toggle */
        .toggle label {
          border-left-color: #0088cc;
          color: #0088cc;
        }
        .toggle.active > label {
          background: #0088cc !important;
          border-color: #0088cc;
        }
        /* Treeview */
        .jstree-default .jstree-hovered {
          background-color: #e6f7ff !important;
        }
        .jstree-default .jstree-clicked {
          background-color: #b3e5ff !important;
        }
        .jstree-default .colored {
          color: #0088cc !important;
        }
        .jstree-default .colored .jstree-icon {
          color: #0088cc !important;
        }
        .jstree-default .colored-icon .jstree-icon {
          color: #0088cc !important;
        }
        /* Widgets */
        .sidebar-widget.widget-tasks ul li:before {
          border-color: #0088cc;
        }
        .widget-twitter-profile {
          background-color: #0088cc;
        }
        .widget-twitter-profile .profile-quote {
          background-color: #0096e0;
        }
        .widget-twitter-profile .profile-quote .quote-footer {
          border-top-color: rgba(0, 170, 255, 0.7);
        }
        .widget-profile-info .profile-info .profile-footer {
          border-top-color: rgba(0, 170, 255, 0.7);
        }
        /* Thumb Info */
        .thumb-info .thumb-info-type {
          background-color: #0088cc;
        }
        /* Social Icons */
        .social-icons-list a {
          background: #0088cc;
        }
        /* Notifications */
        .notifications .notification-menu .notification-title {
          background: #0088cc;
        }
        .notifications .notification-menu .notification-title .label-default {
          background-color: #006699;
        }
        .notifications .notification-menu:before,
        .notifications .notification-icon:before {
          border-bottom-color: #0088cc;
        }
        .ui-pnotify .notification-primary {
          background: rgba(0, 136, 204, 0.95);
        }
        .ui-pnotify.stack-bar-top .notification-primary,
        .ui-pnotify.stack-bar-bottom .notification-primary {
          background: #0088cc;
        }
        .ui-pnotify.notification-primary .notification,
        .ui-pnotify.notification-primary .notification-primary {
          background: rgba(0, 136, 204, 0.95);
        }
        .ui-pnotify.notification-primary.stack-bar-top .notification,
        .ui-pnotify.notification-primary.stack-bar-bottom .notification,
        .ui-pnotify.notification-primary.stack-bar-top .notification-primary,
        .ui-pnotify.notification-primary.stack-bar-bottom .notification-primary {
          background: #0088cc;
        }
        /* Modal */
        .modal-block-primary .fa {
          color: #0088cc;
        }
        .modal-block-primary.modal-header-color .panel-heading {
          background-color: #0088cc;
        }
        .modal-block-primary.modal-full-color .panel {
          background-color: #00a3f5;
        }
        .modal-block-primary.modal-full-color .panel-heading {
          background-color: #0088cc;
        }
        .modal-block-primary.modal-full-color .panel-footer {
          background-color: #00a3f5;
        }
        /* Modal Icon */
        .modal-block-primary .modal-icon .fa {
          color: #0088cc;
        }
        /* Tabs */
        html body .tabs-primary .nav-tabs li a,
        html.dark body .tabs-primary .nav-tabs li a,
        html body .tabs-primary .nav-tabs.nav-justified li a,
        html.dark body .tabs-primary .nav-tabs.nav-justified li a,
        html body .tabs-primary .nav-tabs li a:hover,
        html.dark body .tabs-primary .nav-tabs li a:hover,
        html body .tabs-primary .nav-tabs.nav-justified li a:hover,
        html.dark body .tabs-primary .nav-tabs.nav-justified li a:hover {
          color: #0088cc;
        }
        html body .tabs-primary .nav-tabs li a:hover,
        html.dark body .tabs-primary .nav-tabs li a:hover,
        html body .tabs-primary .nav-tabs.nav-justified li a:hover,
        html.dark body .tabs-primary .nav-tabs.nav-justified li a:hover {
          border-top-color: #0088cc;
        }
        html body .tabs-primary .nav-tabs li.active a,
        html.dark body .tabs-primary .nav-tabs li.active a,
        html body .tabs-primary .nav-tabs.nav-justified li.active a,
        html.dark body .tabs-primary .nav-tabs.nav-justified li.active a,
        html body .tabs-primary .nav-tabs li.active a:hover,
        html.dark body .tabs-primary .nav-tabs li.active a:hover,
        html body .tabs-primary .nav-tabs.nav-justified li.active a:hover,
        html.dark body .tabs-primary .nav-tabs.nav-justified li.active a:hover,
        html body .tabs-primary .nav-tabs li.active a:focus,
        html.dark body .tabs-primary .nav-tabs li.active a:focus,
        html body .tabs-primary .nav-tabs.nav-justified li.active a:focus,
        html.dark body .tabs-primary .nav-tabs.nav-justified li.active a:focus {
          border-top-color: #0088cc;
          color: #0088cc;
        }
        html body .tabs-primary.tabs-bottom .nav-tabs li a:hover,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs li a:hover,
        html body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li a:hover,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li a:hover {
          border-bottom-color: #0088cc;
        }
        html body .tabs-primary.tabs-bottom .nav-tabs li.active a,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs li.active a,
        html body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li.active a,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li.active a,
        html body .tabs-primary.tabs-bottom .nav-tabs li.active a:hover,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs li.active a:hover,
        html body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li.active a:hover,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li.active a:hover,
        html body .tabs-primary.tabs-bottom .nav-tabs li.active a:focus,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs li.active a:focus,
        html body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li.active a:focus,
        html.dark body .tabs-primary.tabs-bottom .nav-tabs.nav-justified li.active a:focus {
          border-top-color: #FFF;
          border-bottom-color: #0088cc;
        }
        html body .tabs-primary.tabs-vertical.tabs-left li a:hover,
        html.dark body .tabs-primary.tabs-vertical.tabs-left li a:hover {
          border-left-color: #0088cc;
        }
        html body .tabs-primary.tabs-vertical.tabs-left li.active a,
        html.dark body .tabs-primary.tabs-vertical.tabs-left li.active a,
        html body .tabs-primary.tabs-vertical.tabs-left li.active a:hover,
        html.dark body .tabs-primary.tabs-vertical.tabs-left li.active a:hover,
        html body .tabs-primary.tabs-vertical.tabs-left li.active a:focus,
        html.dark body .tabs-primary.tabs-vertical.tabs-left li.active a:focus {
          border-left-color: #0088cc;
        }
        html body .tabs-primary.tabs-vertical.tabs-right li a:hover,
        html.dark body .tabs-primary.tabs-vertical.tabs-right li a:hover {
          border-right-color: #0088cc;
        }
        html body .tabs-primary.tabs-vertical.tabs-right li.active a,
        html.dark body .tabs-primary.tabs-vertical.tabs-right li.active a,
        html body .tabs-primary.tabs-vertical.tabs-right li.active a:hover,
        html.dark body .tabs-primary.tabs-vertical.tabs-right li.active a:hover,
        html body .tabs-primary.tabs-vertical.tabs-right li.active a:focus,
        html.dark body .tabs-primary.tabs-vertical.tabs-right li.active a:focus {
          border-right-color: #0088cc;
        }
        /* Simple List */
        ul.simple-bullet-list li:before {
          border-color: #0088cc;
        }
        /* Simple Card List */
        .simple-card-list li.primary {
          background: #0088cc;
        }
        /* Search Results */
        .search-content .search-toolbar .nav-pills li.active a {
          color: #0088cc;
          border-bottom-color: #0088cc;
        }
        .search-results-list .result-thumb .fa {
          background: #0088cc;
        }
        html.dark .search-content .search-toolbar .nav-pills li.active a,
        html.dark .search-content .search-toolbar .nav-pills li.active a:hover,
        html.dark .search-content .search-toolbar .nav-pills li.active a:focus {
          color: #0088cc;
          border-bottom-color: #0088cc;
        }
        /* Time Picker */
        .bootstrap-timepicker-widget table td a:hover {
          background-color: #0088cc;
        }
        /* Checkboxes */
        html.dark .checkbox-primary label:before,
        .checkbox-primary label:before {
          background: #0088cc;
          border-color: #0077b3;
        }
        html.dark .checkbox-text-primary input[type="checkbox"]:checked + label:after,
        .checkbox-text-primary input[type="checkbox"]:checked + label:after {
          color: #0088cc;
        }
        /* Radios */
        html.dark .radio-primary input[type="radio"]:checked + label:after,
        .radio-primary input[type="radio"]:checked + label:after {
          background: #0088cc;
          -webkit-box-shadow: 0px 0px 1px #0088cc;
          box-shadow: 0px 0px 1px #0088cc;
        }
        /* Switch */
        .switch.switch-primary .ios-switch .on-background {
          background: #0088cc;
        }
        /* Progress Bar */
        .progress-bar {
          background-color: #0088cc;
        }
        .progress .progress-bar-primary {
          background-color: #0088cc;
        }
        /* Slider */
        .slider-primary .ui-slider-range,
        .slider-primary .ui-slider-handle {
          background: #0088cc;
        }
        .slider-gradient.slider-primary .ui-slider-range,
        .slider-gradient.slider-primary .ui-slider-handle {
          background-image: -webkit-linear-gradient(left, #00aaff 0, #0088cc 50%, #006699 100%);
          background-image: linear-gradient(left, #00aaff 0, #0088cc 50%, #006699 100%);
        }
        .slider-gradient.ui-slider-vertical.slider-primary .ui-slider-range,
        .slider-gradient.ui-slider-vertical.slider-primary .ui-slider-handle {
          background-image: -webkit-linear-gradient(to right, #00aaff 0, #0088cc 50%, #006699 100%);
          background-image: linear-gradient(to right, #00aaff 0, #0088cc 50%, #006699 100%);
        }
        /* DatePicker */
        .datepicker table {
          width: 100%;
        }
        .datepicker table thead tr th.prev:hover,
        .datepicker table thead tr th.next:hover {
          background: #0088cc;
        }
        .datepicker table thead tr:first-child th:hover {
          background: #0088cc;
        }
        .datepicker table tr td span:hover {
          background: #0088cc;
        }
        .datepicker table tr td.day:hover {
          background: #0088cc;
        }
        .datepicker table tfoot tr th:hover {
          background: #0088cc;
        }
        /* DatePicker: Dark */
        html.dark .datepicker.datepicker-primary table thead tr th.prev:hover,
        .datepicker.datepicker-dark table thead tr th.prev:hover,
        html.dark .datepicker.datepicker-primary table thead tr th.next:hover,
        .datepicker.datepicker-dark table thead tr th.next:hover {
          background: #0088cc;
        }
        html.dark .datepicker.datepicker-primary table tbody tr td.day:hover,
        .datepicker.datepicker-dark table tbody tr td.day:hover {
          background: #0088cc;
        }
        html.dark .datepicker.datepicker-primary table tbody tr td.day.active,
        .datepicker.datepicker-dark table tbody tr td.day.active {
          background: #0088cc;
        }
        /* DatePicker: Primary */
        .datepicker.datepicker-primary table thead tr:first-child {
          background-color: #0088cc;
        }
        .datepicker.datepicker-primary table thead tr:first-child th:hover {
          background-color: #006699;
        }
        .datepicker.datepicker-primary table thead tr:last-child {
          background-color: #0099e6;
        }
        .datepicker.datepicker-primary table thead tr:last-child th:hover {
          background-color: #0088cc;
        }
        .datepicker.datepicker-primary table tbody tr td.day:hover {
          background: #0088cc;
        }
        .datepicker.datepicker-primary table tbody tr td.day.active {
          background: #0088cc;
        }
        /* Select 2 */
        .select2-container-multi .select2-choices .select2-search-choice {
          background: #0088cc;
        }
        /* Wizard */
        .wizard-steps > li.active .badge {
          background-color: #0088cc;
        }
        .wizard-steps > li.active a,
        .wizard-steps > li.active a:hover,
        .wizard-steps > li.active a:focus {
          border-top-color: #0088cc;
        }
        .wizard-tabs ul > li.active .badge {
          background-color: #0088cc;
        }
        html .wizard-progress .steps-progress .progress-indicator,
        html.dark .wizard-progress .steps-progress .progress-indicator {
          background: #0088cc;
        }
        html .wizard-progress .wizard-steps li.completed a span,
        html.dark .wizard-progress .wizard-steps li.completed a span {
          border-color: #0088cc;
          background: #0088cc;
        }
        html .wizard-progress .wizard-steps li.active a span,
        html.dark .wizard-progress .wizard-steps li.active a span {
          color: #0088cc;
          border-color: #0088cc;
        }
        /* Tables */
        .table > thead > tr > td.primary,
        .table > tbody > tr > td.primary,
        .table > tfoot > tr > td.primary,
        .table > thead > tr > th.primary,
        .table > tbody > tr > th.primary,
        .table > tfoot > tr > th.primary,
        .table > thead > tr.primary > td,
        .table > tbody > tr.primary > td,
        .table > tfoot > tr.primary > td,
        .table > thead > tr.primary > th,
        .table > tbody > tr.primary > th,
        .table > tfoot > tr.primary > th {
          background-color: #0088cc;
        }
        /* Data Tables Loading */
        .dataTables_processing {
          background-color: #0088cc;
        }
        /* Liquid Meter */
        .liquid-meter-wrapper .liquid-meter-selector a.active {
          color: #0088cc;
        }
    </style>
        <link rel="stylesheet/less" href="http://preview.oklerthemes.com/porto-admin/1.3.0/assets/vendor/style-switcher/less/extension.less">
        <style type="text/css" id="less:porto-admin-1:3:0-assets-vendor-style-switcher-less-extension">/* Checkboxes */
            html.dark .checkbox-primary label:before,
            .checkbox-primary label:before {
              background: #0088cc;
              border-color: #0077b3;
            }
            html.dark .checkbox-text-primary input[type="checkbox"]:checked + label:after,
            .checkbox-text-primary input[type="checkbox"]:checked + label:after {
              color: #0088cc;
            }
            /* Radios */
            html.dark .radio-primary input[type="radio"]:checked + label:after,
            .radio-primary input[type="radio"]:checked + label:after {
              background: #0088cc;
              -webkit-box-shadow: 0px 0px 1px #0088cc;
              box-shadow: 0px 0px 1px #0088cc;
            }
            /* Switch */
            .switch.switch-primary .ios-switch .on-background {
              background: #0088cc;
            }
            /* Progress Bar */
            .progress-bar {
              background-color: #0088cc;
            }
            .progress .progress-bar-primary {
              background-color: #0088cc;
            }
            /* Slider */
            .slider-primary .ui-slider-range,
            .slider-primary .ui-slider-handle {
              background: #0088cc;
            }
            .slider-gradient.slider-primary .ui-slider-range,
            .slider-gradient.slider-primary .ui-slider-handle {
              background-image: -webkit-linear-gradient(left, #00aaff 0, #0088cc 50%, #006699 100%);
              background-image: linear-gradient(left, #00aaff 0, #0088cc 50%, #006699 100%);
            }
            .slider-gradient.ui-slider-vertical.slider-primary .ui-slider-range,
            .slider-gradient.ui-slider-vertical.slider-primary .ui-slider-handle {
              background-image: -webkit-linear-gradient(to right, #00aaff 0, #0088cc 50%, #006699 100%);
              background-image: linear-gradient(to right, #00aaff 0, #0088cc 50%, #006699 100%);
            }
            /* DatePicker */
            .datepicker table {
              width: 100%;
            }
            .datepicker table thead tr th.prev:hover,
            .datepicker table thead tr th.next:hover {
              background: #0088cc;
            }
            .datepicker table thead tr:first-child th:hover {
              background: #0088cc;
            }
            .datepicker table tr td span:hover {
              background: #0088cc;
            }
            .datepicker table tr td.day:hover {
              background: #0088cc;
            }
            .datepicker table tfoot tr th:hover {
              background: #0088cc;
            }
            /* DatePicker: Dark */
            html.dark .datepicker.datepicker-primary table thead tr th.prev:hover,
            .datepicker.datepicker-dark table thead tr th.prev:hover,
            html.dark .datepicker.datepicker-primary table thead tr th.next:hover,
            .datepicker.datepicker-dark table thead tr th.next:hover {
              background: #0088cc;
            }
            html.dark .datepicker.datepicker-primary table tbody tr td.day:hover,
            .datepicker.datepicker-dark table tbody tr td.day:hover {
              background: #0088cc;
            }
            html.dark .datepicker.datepicker-primary table tbody tr td.day.active,
            .datepicker.datepicker-dark table tbody tr td.day.active {
              background: #0088cc;
            }
            /* DatePicker: Primary */
            .datepicker.datepicker-primary table thead tr:first-child {
              background-color: #0088cc;
            }
            .datepicker.datepicker-primary table thead tr:first-child th:hover {
              background-color: #006699;
            }
            .datepicker.datepicker-primary table thead tr:last-child {
              background-color: #0099e6;
            }
            .datepicker.datepicker-primary table thead tr:last-child th:hover {
              background-color: #0088cc;
            }
            .datepicker.datepicker-primary table tbody tr td.day:hover {
              background: #0088cc;
            }
            .datepicker.datepicker-primary table tbody tr td.day.active {
              background: #0088cc;
            }
            /* Select 2 */
            .select2-container-multi .select2-choices .select2-search-choice {
              background: #0088cc;
            }
            /* Wizard */
            .wizard-steps > li.active .badge {
              background-color: #0088cc;
            }
            .wizard-steps > li.active a,
            .wizard-steps > li.active a:hover,
            .wizard-steps > li.active a:focus {
              border-top-color: #0088cc;
            }
            .wizard-tabs ul > li.active .badge {
              background-color: #0088cc;
            }
            html .wizard-progress .steps-progress .progress-indicator,
            html.dark .wizard-progress .steps-progress .progress-indicator {
              background: #0088cc;
            }
            html .wizard-progress .wizard-steps li.completed a span,
            html.dark .wizard-progress .wizard-steps li.completed a span {
              border-color: #0088cc;
              background: #0088cc;
            }
            html .wizard-progress .wizard-steps li.active a span,
            html.dark .wizard-progress .wizard-steps li.active a span {
              color: #0088cc;
              border-color: #0088cc;
            }
            /* Tables */
            .table > thead > tr > td.primary,
            .table > tbody > tr > td.primary,
            .table > tfoot > tr > td.primary,
            .table > thead > tr > th.primary,
            .table > tbody > tr > th.primary,
            .table > tfoot > tr > th.primary,
            .table > thead > tr.primary > td,
            .table > tbody > tr.primary > td,
            .table > tfoot > tr.primary > td,
            .table > thead > tr.primary > th,
            .table > tbody > tr.primary > th,
            .table > tfoot > tr.primary > th {
              background-color: #0088cc;
            }
            /* Data Tables Loading */
            .dataTables_processing {
              background-color: #0088cc;
            }
            /* Liquid Meter */
            .liquid-meter-wrapper .liquid-meter-selector a.active {
              color: #0088cc;
            }
        </style>
        <link rel="stylesheet" href="css/colorpicker.css">
</head>
<body scroll="no" style="overflow: hidden;">
    <form id="frmHome" runat="server">
    <table border="0" cellpadding="1" cellspacing="1" style="width:100%;">
        <tr align="center" valign="middle">
            <td>
                <table border="0" cellpadding="1" cellspacing="1" style="width:500px; overflow:hidden;">
                    <tr style="">
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td style="position:relative; bottom:-10px;">
                            &nbsp;</td>
                    </tr>
                    <tr style="">
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td style="position:relative; bottom:-10px;">
                            &nbsp;</td>
                    </tr>
                    <tr style="">
                        <td align="left">
                            <img src="Images/LogoMD202x70.png" height="70" width="202" alt="DNA+" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="position:relative; bottom:-10px; position:relative; right:-30px;">
                            <div style="background-color:#E43135;width:110px;height:60px;">
                                <h2 style="color:#fff;font-size:14px !IMPORTANT;font-weight:bold;"><div style="background:url(Images/user.png); background-repeat:no-repeat; width:21px; height:23px;position:relative;margin-left:10px;float:left"></div>L O G I N</h2>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                        <div style="border-top: 5px solid #E43135;background-color:#fff;">
                            <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                <tr style="height:30px;">
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr >
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Usuário" style="margin-left:30px;float:left"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr >
                                    <td colspan="4">
                                    <input runat="server" id="txtLogin" name="username" type="text" class="form-control input-lg" maxlength="15" style="font-size:18px; text-transform:uppercase; height:25px; width:400px; margin-left:30px;float:left" required="required" title="O seu login é obrigatório." />
                                    
										<span class="icon icon-lg">
											<div style="background:url(Images/user.png); background-repeat:no-repeat; background-color:#fff; width:21px; height:23px;position:relative;top:10px;right:35px;"></div>
										</span>
									
                                    </td>
                                </tr>
                                <tr >
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr >
                                    <td>
                                    <asp:Label ID="Label2" runat="server" Text="Senha" style="margin-left:30px;float:left"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr >
                                    <td colspan="4">
                                    <input runat="server" id="txtSenha" name="pws" type="password" class="form-control input-lg" maxlength="20" style="font-size:18px; text-transform:uppercase; height:25px; width:400px; margin-left:30px;float:left" required="required" title="O seu login é obrigatório." />
                                    <span class="icon icon-lg">
											<div style="background:url(Images/cadeado.png); background-repeat:no-repeat; width:21px; height:23px;position:relative;top:10px;right:35px;"></div>
										</span>
                                    </td>
                                </tr>
                                <tr >
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr >
                                    <td colspan="4">
                                    <div class="col-sm-4 text-right" style="position:relative; right:16px;">
                                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" 
                                        class="btn btn-primary hidden-xs" onclick="btnEntrar_Click"></asp:Button>
								</div>
                                    </td>
                                </tr>
                                <tr >
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        </td>
                    </tr>
                    <tr style="">
                        <td align="center" colspan="4">
                            <p class="text-center text-muted mt-md mb-md">&copy; Copyright © 2015 DNA+. Todos os Direitos Reservados</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <!-- Vendor -->
    <script src="js/jquery.js"></script>
    <script src="js/jquery.browser.mobile.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/style.switcher.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/nanoscroller.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script src="js/magnific-popup.js"></script>
    <script src="js/jquery.placeholder.js"></script>
    <!-- Theme Base, Components and Settings -->
    <script src="js/theme.js"></script>
    <!-- Theme Custom -->
    <script src="js/theme.custom.js"></script>
    <!-- Theme Initialization Files -->
    <script src="js/theme.init.js"></script>
    <!-- Analytics to Track Preview Website -->
    <script>        (function (i, s, o, g, r, a, m) { i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () { (i[r].q = i[r].q || []).push(arguments) }, i[r].l = 1 * new Date(); a = s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m) })(window, document, 'script', 'http://www.google-analytics.com/analytics.js', 'ga'); ga('create', 'UA-42715764-8', 'auto'); ga('send', 'pageview');		</script>
    </form>
</body>
</html>
