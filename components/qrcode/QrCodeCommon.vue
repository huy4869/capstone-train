<template>
  <div class="scan-code">
   <span class="scan-code__angle scan-code__angle--top"></span>
    <qrcode-vue class="qrcode" :value="value" :size="size" level="H" />
   <span class="scan-code__angle scan-code__angle--bottom"></span>
  </div>
</template>
<script>
import QrcodeVue from 'qrcode.vue'

export default {
  components: {
    QrcodeVue
  },
  data() {
    return {
      value: 'https://www.facebook.com/profile.php?id=100004980377064',
      size: 200
    }
  }
}
</script>
