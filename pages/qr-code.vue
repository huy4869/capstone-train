<template>
  <div class="qr-code-main">
    <qr-code-common />
    <qr-code-stream />
  </div>
</template>

<script>
import QrCodeCommon from '@/components/qrcode/QrCodeCommon.vue'
import QrCodeStream from '@/components/qrcode/QrCodeStream.vue'
export default {
  name: 'QrCode',
  components: {
    QrCodeCommon,
    QrCodeStream
  }
}
</script>

<style lang="scss" scoped></style>
